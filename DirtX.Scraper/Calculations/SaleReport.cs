using DirtX.Scraper.Data.Models;
using static DirtX.Scraper.Shared.Constants;

namespace DirtX.Calculations
{
    public static class SaleReport
    {
        public static void SoldMotorcyclesList(List<SoldMotorcycle> soldEntriesSet, List<MotorcycleMarketPrice> marketPricesSet, StreamWriter saleReportWriter)
        {
            foreach (var entry in soldEntriesSet)
            {
                if (entry.Make?.Title is not null && entry.Year?.ManufactureYear is not 0)
                {
                    MotorcycleMarketPrice currentPrice = marketPricesSet
                        .FirstOrDefault(m => m.Make?.Title == entry.Make.Title
                                          && m.Year?.ManufactureYear == entry.Year.ManufactureYear);

                    if (currentPrice is not null)
                    {
                        saleReportWriter.WriteLine($"{entry.Make.Title}, {entry.Year.ManufactureYear}, {entry.Displacement}, {entry.Price}, {currentPrice.AvgPrice:f0}, {entry.DateAdded:d}, {entry.DateSold:d}");
                    }
                }
            }
        }

        public static void CalculateAbsoluteAverages(List<SoldMotorcycle> soldEntriesSet, StreamWriter saleReportWriter)
        {
            decimal averagePrice = soldEntriesSet.Average(m => m.Price);
            double averageYear = soldEntriesSet.Average(m => m.Year.ManufactureYear);

            saleReportWriter.WriteLine(String.Format(SoldMotoAvgPrice, averagePrice));
            saleReportWriter.WriteLine(String.Format(SoldMotoAvgYear, Math.Round(averageYear)));
        }

        public static void EngineDisplacementCount(List<SoldMotorcycle> soldEntriesSet, StreamWriter saleReportWriter)
        {
            int[] engineDisplacements = { 250, 350, 450 };

            double totalCount = soldEntriesSet.Count(m => engineDisplacements.Contains(m.Displacement));

            foreach (int cc in engineDisplacements)
            {
                double count = soldEntriesSet.Count(m => m.Displacement == cc);
                double ratio = (count / totalCount) * 100.0;

                saleReportWriter.WriteLine(String.Format(SoldMotoCcRatio, cc, count, totalCount, ratio));
            }
        }

        public static void CountOfSalesPerMake(List<SoldMotorcycle> soldEntriesSet, StreamWriter saleReportWriter)
        {
            var makeCountPairs = new Dictionary<string, int>();

            foreach (var motorcycle in soldEntriesSet)
            {
                var make = motorcycle.Make?.Title;
                if (make is not null)
                {
                    if (!makeCountPairs.ContainsKey(make))
                    {
                        makeCountPairs.Add(make, 0);
                    }
                }
            }

            foreach (var motorcycle in soldEntriesSet)
            {
                var make = motorcycle.Make?.Title;
                if (make is not null)
                {
                    makeCountPairs[make]++;
                }
            }

            foreach (var kvp in makeCountPairs)
            {
                saleReportWriter.WriteLine(String.Format(SoldMotoByMake, kvp.Value, kvp.Key));
            }
        }
    }
}
