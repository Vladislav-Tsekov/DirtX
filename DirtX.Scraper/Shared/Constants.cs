namespace DirtX.Scraper.Shared
{
    public class Constants
    {
        // Base Constants
        public const string BaseUrl = "https://www.mobile.bg/obiavi/motori/krosov/ot-2006/do-2024/p-";
        public const int MaxPages = 50;
        public const int DoomCounterDefault = 0;

        // Output
        public const string ScrapeSuccess = "Data was scraped successfully! Files were updated accordingly.";
        public const string ScraperHasRunToday = "The scraper has already run today. You can download up-to-date files below:";
        public const string ScrapeFailed = "The scraper has failed gathering data!";

        // Statistics Constants
        public const double trimPercentage = 0.20;
        public const decimal deviationThreshold = 1.0m;

        // Scraping Patterns
        public const string TitleNodes = "//a[@class='mmmL']";
        public const string PriceNodes = "//span[@class='price']";
        public const string DescriptionNodes = "//td[(contains(@colspan,'3') or contains(@colspan,'4')) and contains(@style,'padding-left:')]";
        public const string LinkNodes = "//a[@class='photoLinkL']";

        // CSV Files Constants
        public const string UnusualValuesVariance = "Make,Year,Count,Variance";
        public const string UnusualValuesRange = "Make,Year,Count,Range";

        public const string AllLinksTitles = "Make, CC, Year, Price, Link";
        public const string AllLinksMotoInfo = "{0},{1},{2},{3},{4}";
        public const string AllLinksPriceChange = "Updating {0}. Old Price: {1:0}, New Price: {2:0}";

        public const string MarketPriceTitles = "Make, Year, Count, Average Price, Mean Price, StdDev Price, Median Price, Price Variance";
        public const string MarketPriceMotoInfo = "{0}, {1}, {2}, {3:0}, {4:0}, {5:0}, {6:0}, {7:f3}";
        public const string MarketByCcTitle = "{0} out of {1} are {2} cc. ({3:f2}%)";
        public const string MarketByCc = "There are currently {0} Motocross announcements (with valid CC).";

        public const string SoldMotoTitles = "Make, Year, CC, Price Sold, Avg Market Price, Date Listed, Date Sold";
        public const string SoldMotoAvgPrice = "The average price for all sold entries is: {0:f2}";
        public const string SoldMotoAvgYear = "The average year for all sold entries is: {0}";
        public const string SoldMotoCcRatio = "{0}cc: {1} out of {2}. Ratio of {3:f2}%";
        public const string SoldMotoByMake = "A total of {0} {1} sold!";

        // CSV Files Names
        public const string AllLinksCsv = "AllMotocrossLinks.csv";
        public const string MarketPriceCsv = "AvgPriceMotocross.csv";
        public const string MarketOverviewCsv = "MarketOverview.csv";
        public const string SaleReportCsv = "SaleReport.csv";
        public const string MarketOutliersCsv = "MarketOutliers.csv";
    }
}
