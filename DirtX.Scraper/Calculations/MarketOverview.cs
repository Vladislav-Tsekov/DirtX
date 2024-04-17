using DirtX.Scraper.Data.Models;
using System.Text;
using static DirtX.Scraper.Shared.Constants;

namespace DirtX.Calculations
{
    public class MarketOverview
    {
        public static void MarketShareByEngineDisplacement(HashSet<Motorcycle> entriesSet, StreamWriter marketWriter)
        {
            int totalEntries = entriesSet.Where(m => m.Displacement == 250 || m.Displacement == 350 || m.Displacement == 450).Count();

            Dictionary<int, int> displacementCount = entriesSet
                .Where(m => m.Displacement == 250 || m.Displacement == 350 || m.Displacement == 450)
                .GroupBy(m => m.Displacement)
                .OrderByDescending(m => m.Key)
                .ToDictionary(g => g.Key, g => g.Count());

            StringBuilder sb = new();
            sb.AppendLine(String.Format(MarketByCc, totalEntries));

            foreach (var ccEntry in displacementCount)
            {
                string cc = ccEntry.Key.ToString();
                double percentage = (double)ccEntry.Value / totalEntries * 100;
                sb.AppendLine(String.Format(MarketByCcTitle, ccEntry.Value, totalEntries, cc, percentage));
            }

            marketWriter.Write(sb.ToString());
        }

        public static void MarketShareByMakeAndYear(List<MotorcycleMarketPrice> pricesList, StreamWriter marketWriter)
        {
            SortedDictionary<string, int> makeCountPairs = new();
            SortedDictionary<int, int> yearCountPairs = new();

            foreach (var motorcycle in pricesList)
            {
                if (motorcycle.Make != null)
                {
                    if (!makeCountPairs.ContainsKey(motorcycle.Make.Title))
                    {
                        makeCountPairs.Add(motorcycle.Make.Title, 0);
                    }
                }

                if (motorcycle.Year != null && motorcycle.Year.ManufactureYear != 0)
                {
                    if (!yearCountPairs.ContainsKey(motorcycle.Year.ManufactureYear))
                    {
                        yearCountPairs.Add(motorcycle.Year.ManufactureYear, 0);
                    }
                }
            }

            foreach (var motorcycle in pricesList)
            {
                if (motorcycle.Make != null)
                {
                    makeCountPairs[motorcycle.Make.Title] += motorcycle.MotoCount;

                    yearCountPairs[motorcycle.Year.ManufactureYear] += motorcycle.MotoCount;
                }
            }

            StringBuilder sb = new();

            foreach (var kvp in makeCountPairs)
            {
                sb.AppendLine($"{kvp.Key.ToUpper()}, {kvp.Value}");
            }

            foreach (var kvp in yearCountPairs)
            {
                sb.AppendLine($"{kvp.Key}, {kvp.Value}");
            }

            marketWriter.Write(sb.ToString().TrimEnd());
        }
    }
}
