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
        }
    }
}
