using DirtX.Calculations;
using DirtX.Scraper.Data;
using DirtX.Scraper.Data.Models;
using DirtX.Scraper.Shared;
using Microsoft.EntityFrameworkCore;
using static DirtX.Scraper.Shared.Constants;

namespace DirtX.Scraper
{
    public static class DataAnalysis
    {
        public static async Task MarketOverviewReport(ScraperDbContext context, ScraperSettings settings)
        {
            List<Motorcycle> entriesList = await context.Motorcycles.ToListAsync();
            List<MotorcycleMarketPrice> pricesList = await context.MarketPrices.ToListAsync();

            HashSet<Motorcycle> entriesSet = new(entriesList);

            StreamWriter marketWriter = new(Path.Combine(settings.GetScraperOutputDirectory(), MarketOverviewCsv));
            marketWriter.WriteLine($"{DateTime.Now:d}");

            MarketOverview.MarketShareByEngineDisplacement(entriesSet, marketWriter);
            MarketOverview.MarketShareByMakeAndYear(pricesList, marketWriter);

            marketWriter.Dispose();

            return;
        }

        public static async Task UnusualValuesReport(ScraperDbContext context, ScraperSettings settings)
        {
            List<MotorcycleMarketPrice> highVariance = await context.MarketPrices
                .Where(m => m.PriceVariance > 0.19m)
                .ToListAsync();

            List<MotorcycleMarketPrice> extremeRange = await context.MarketPrices
                .Where(m => m.PriceRange > 2000)
                .ToListAsync();

            StreamWriter marketOutliers = new(Path.Combine(settings.GetScraperOutputDirectory(), MarketOutliersCsv));

            marketOutliers.WriteLine($"{DateTime.Now:d}");
            marketOutliers.WriteLine(UnusualValuesVariance);

            foreach (var entity in highVariance)
            {
                marketOutliers.WriteLine($"{entity.Make.Title},{entity.Year.ManufactureYear},{entity.MotoCount},{entity.PriceVariance:f3}");
            }

            marketOutliers.WriteLine(UnusualValuesRange);

            foreach (var entity in extremeRange)
            {
                marketOutliers.WriteLine($"{entity.Make.Title} , {entity.Year.ManufactureYear},{entity.MotoCount},{entity.PriceRange:f0}");
            }

            marketOutliers.Dispose();

            return;
        }

        public static async Task SoldMotorcyclesReport(ScraperDbContext context, ScraperSettings settings)
        {
            List<SoldMotorcycle> soldEntries = await context.SoldMotorcycles
                .OrderBy(m => m.Make.Title)
                .ThenBy(m => m.Year.ManufactureYear)
                .ToListAsync();

            if (soldEntries.Count < 1)
            {
                return;
            }

            List<MotorcycleMarketPrice> marketPrices = await context.MarketPrices
                .OrderBy(m => m.Make.Title)
                .ThenBy(m => m.Year.ManufactureYear)
                .ToListAsync();

            StreamWriter salesWriter = new(Path.Combine(settings.GetScraperOutputDirectory(), SaleReportCsv));
            salesWriter.WriteLine(DateTime.Now);
            salesWriter.WriteLine(SoldMotoTitles);

            SaleReport.SoldMotorcyclesList(soldEntries, marketPrices, salesWriter);
            SaleReport.CalculateAbsoluteAverages(soldEntries, salesWriter);
            SaleReport.EngineDisplacementCount(soldEntries, salesWriter);
            SaleReport.CountOfSalesPerMake(soldEntries, salesWriter);

            salesWriter.Dispose();

            return;
        }
    }
}
