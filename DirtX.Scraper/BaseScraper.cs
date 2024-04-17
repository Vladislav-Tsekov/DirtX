using DirtX.Scraper.Data;
using DirtX.Scraper.Models;
using DirtX.Scraper.Shared;
using HtmlAgilityPack;
using System.Text;
using System.Text.RegularExpressions;
using static DirtX.Scraper.Shared.Constants;

namespace DirtX.Scraper
{
    public class BaseScraper
    {
        private readonly ScraperDbContext context;
        private readonly ScraperSettings settings;

        public BaseScraper(ScraperDbContext _context, ScraperSettings _settings)
        {
            context = _context;
            settings = _settings;
        }

        public async Task<string> Run()
        {
            DateTime? lastRunDate = settings.GetLastRunDateAsync();

            if (lastRunDate.HasValue && lastRunDate.Value.Date == DateTime.Today)
            {
                return ScraperHasRunToday;
            }

            settings.UpdateLastRunDateAsync();
            settings.Config();

            List<string> makes = new();
            List<int> displacements = new();
            List<decimal> prices = new();
            List<int> years = new();
            List<string> links = new();

            using HttpClient client = new();

            string baseUrl = BaseUrl;

            int maxPages = MaxPages;
            int doomCounter = DoomCounterDefault;

            for (int i = 1; i <= maxPages; i++)
            {
                if (doomCounter > 1)
                {
                    break;
                }

                string currentPage = baseUrl + i;

                HttpResponseMessage httpResponse = await client.GetAsync(currentPage);

                if (httpResponse.IsSuccessStatusCode)
                {
                    Stream contentStream = await httpResponse.Content.ReadAsStreamAsync();

                    using StreamReader reader = new(contentStream, Encoding.GetEncoding("windows-1251"));
                    string htmlContent = await reader.ReadToEndAsync();
                    HtmlDocument doc = new();
                    doc.LoadHtml(htmlContent);

                    HtmlNodeCollection titleNodes = doc.DocumentNode.SelectNodes(TitleNodes);
                    HtmlNodeCollection priceNodes = doc.DocumentNode.SelectNodes(PriceNodes);
                    HtmlNodeCollection descriptionNodes = doc.DocumentNode.SelectNodes(DescriptionNodes);
                    HtmlNodeCollection linkNodes = doc.DocumentNode.SelectNodes(LinkNodes);

                    if (titleNodes is not null)
                    {
                        foreach (var titleNode in titleNodes)
                        {
                            string title = titleNode.InnerText;

                            if (string.IsNullOrEmpty(title))
                            {
                                continue;
                            }
                            else
                            {
                                string[] titleTokens = title.Split();

                                string make = titleTokens[0];
                                makes.Add(make);

                                int cc = 0;

                                foreach (string cubicCent in titleTokens)
                                {
                                    Match ccMatch = Regex.Match(cubicCent, @"\d{3}");

                                    if (ccMatch.Success)
                                    {
                                        string ccValue = ccMatch.Value;
                                        cc = int.Parse(ccValue);
                                        displacements.Add(cc);
                                        break;
                                    }
                                }

                                if (cc == 0)
                                {
                                    displacements.Add(cc);
                                }
                            }
                        }
                    }
                    else
                    {
                        doomCounter++;
                    }

                    if (priceNodes is not null)
                    {
                        foreach (var priceNode in priceNodes)
                        {
                            string priceInnerText = priceNode.InnerText;
                            string priceEdit = Regex.Replace(priceInnerText, @"[^\d]", "");

                            if (decimal.TryParse(priceEdit, out decimal price))
                            {
                                prices.Add(price);
                            }
                            else
                            {
                                prices.Add(0);
                            }
                        }
                    }
                    else
                    {
                        doomCounter++;
                    }

                    if (descriptionNodes is not null)
                    {
                        foreach (var infoNode in descriptionNodes)
                        {
                            string infoText = infoNode.InnerText;
                            Match yearMatch = Regex.Match(infoText, @"\d{4}");

                            if (yearMatch.Success)
                            {
                                int year = int.Parse(yearMatch.Value);
                                years.Add(year);
                            }
                            else
                            {
                                years.Add(0);
                            }
                        }
                    }
                    else
                    {
                        doomCounter++;
                    }

                    if (linkNodes is not null)
                    {
                        foreach (var href in linkNodes)
                        {
                            string link = href.GetAttributeValue("href", "");
                            string modifiedLink = link[2..40];
                            links.Add(modifiedLink);
                        }
                    }
                    else
                    {
                        doomCounter++;
                    }
                }
                else
                {
                    return ScrapeFailed;
                }
            }

            HashSet<ScrapeMotorcycle> motorcycles = new();

            for (int i = 0; i < makes.Count; i++)
            {
                ScrapeMotorcycle currentMoto = new(makes[i], displacements[i], years[i], prices[i], links[i]);
                motorcycles.Add(currentMoto);
            }

            List<ScrapeMotorcycle> scrapedMoto = motorcycles
                .Where(m => m.Price > 3000 && m.Year >= 2006 && m.Year <= DateTime.Now.Year)
                .OrderBy(m => m.Make)
                .ThenBy(m => m.Year)
                .ThenBy(m => m.Price)
                .ToList();

            List<string> distinctMakes = makes.Distinct().OrderBy(m => m).ToList();
            List<int> distinctYears = years.Distinct().OrderBy(y => y).ToList();

            await DataExport.UpdateMakesTable(distinctMakes, context);
            await DataExport.UpdateYearsTable(distinctYears, context);
            await DataExport.AddMotorcycleEntries(scrapedMoto, context, settings);
            await DataExport.AddMarketPrices(scrapedMoto, context, settings);
            await DataExport.TransferSoldEntries(context);

            await DataAnalysis.MarketOverviewReport(context, settings);
            await DataAnalysis.SoldMotorcyclesReport(context, settings);
            await DataAnalysis.UnusualValuesReport(context, settings);

            return ScrapeSuccess;
        }
    }
}
