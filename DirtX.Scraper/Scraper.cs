using DirtX.Scraper.Data.Models.Enums;
using DirtX.Scraper.Models;
using HtmlAgilityPack;
using System.Text;
using System.Text.RegularExpressions;
using static DirtX.Scraper.Settings;

namespace DirtX.Scraper
{
    public class Scraper
    {
        public async Task Run(string vehicleClass)
        {
            Config();

            string motoClass = vehicleClass.ToLower();

            List<string> makes = new();
            List<int> displacements = new();
            List<decimal> prices = new();
            List<int> years = new();
            List<string> links = new();

            using HttpClient client = new();

            string baseUrl = string.Empty;

            if (motoClass == "motocross")
            {
                baseUrl = MxBaseUrl;
            }
            else if (motoClass == "enduro")
            {
                baseUrl = EnduroBaseUrl;
            }

            int maxPages = 150;
            int doomCounter = 0;

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

                    if (titleNodes != null)
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
                        Console.WriteLine("No titles found on the page.");
                    }

                    if (priceNodes != null)
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
                        Console.WriteLine("No prices found on the page.");
                    }

                    if (descriptionNodes != null)
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
                        Console.WriteLine("No years found on the page.");
                    }

                    if (linkNodes != null)
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
                        Console.WriteLine("No matching links found.");
                    }
                }
                else
                {
                    Console.WriteLine("Failed to retrieve the web page.");
                    return;
                }
            }

            HashSet<Motorcycle> motorcycles = new();

            Category ctg = Category.Motocross;

            if (motoClass == "enduro")
            {
                ctg = Category.Enduro;
            }

            for (int i = 0; i < makes.Count; i++)
            {
                Motorcycle currentMoto = new(makes[i], displacements[i], years[i], prices[i], links[i], ctg);
                motorcycles.Add(currentMoto);
            }

            List<Motorcycle> scrapedMoto = motorcycles
                                .Where(m => m.Price > 3000 && m.Year >= 2006 && m.Year <= DateTime.Now.Year)
                                .OrderBy(m => m.Make)
                                .ThenBy(m => m.Year)
                                .ThenBy(m => m.Price)
                                .ToList();

            List<string> distinctMakes = makes.Distinct().OrderBy(m => m).ToList();
            List<int> distinctYears = years.Distinct().OrderBy(y => y).ToList();
        }
    }
}
