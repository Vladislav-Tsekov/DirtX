using HtmlAgilityPack;
using System.Text;
using System.Text.RegularExpressions;
using static DirtX.Scraper.Settings;

namespace DirtX.Scraper
{
    public class Scraper
    {
        public async Task Run(string category)
        {
            Config();

            List<string> makes = new();
            List<int> displacements = new();
            List<decimal> prices = new();
            List<int> years = new();
            List<string> links = new();

            using HttpClient client = new();

            string baseUrl = string.Empty;
            if (category.ToLower() == "motocross")
            {
                baseUrl = MxBaseUrl;
            }
            else
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

                }
            }
        }
    }
}
