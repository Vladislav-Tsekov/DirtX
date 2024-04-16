using static DirtX.Scraper.Shared.Constants;

namespace DirtX.Calculations
{
    public class MeanValues
    {
        public static decimal StdDev(IEnumerable<decimal> prices)
        {
            decimal[] pricesArray = prices.ToArray();
            decimal mean = pricesArray.Average();

            decimal standardDeviation = (decimal)Math.Sqrt(pricesArray.Select(x => (double)Math.Pow((double)(x - mean), 2)).Average());
            decimal deviationLimit = deviationThreshold * standardDeviation;

            decimal[] trimmedData = pricesArray.Where(x => Math.Abs(x - mean) <= deviationLimit).ToArray();
            decimal trimmedMean = trimmedData.Average();

            return trimmedMean;
        }

        public static decimal MeanTrim(IEnumerable<decimal> prices)
        {
            decimal[] pricesArray = prices.ToArray();
            decimal[] sortedPrices = pricesArray.OrderBy(x => x).ToArray();

            int trimCount = (int)(pricesArray.Length * trimPercentage);

            decimal[] trimmedData = sortedPrices.Skip(trimCount).Take(pricesArray.Length - 2 * trimCount).ToArray();
            decimal trimmedMean = trimmedData.Average();

            return trimmedMean;
        }

        public static decimal Median(IEnumerable<decimal> prices)
        {
            decimal[] pricesArray = prices.ToArray();
            Array.Sort(pricesArray);

            if (pricesArray.Length % 2 == 0)
            {
                int middleIndex1 = pricesArray.Length / 2 - 1;
                int middleIndex2 = pricesArray.Length / 2;

                return (pricesArray[middleIndex1] + pricesArray[middleIndex2]) / 2.0m;
            }
            else
            {
                int middleIndex = pricesArray.Length / 2;

                return pricesArray[middleIndex];
            }
        }

        public static decimal Mode(IEnumerable<decimal> prices)
        {
            var groupedPrices = prices.GroupBy(x => x);
            int maxFrequency = groupedPrices.Max(g => g.Count());

            if (groupedPrices.Count(g => g.Count() == maxFrequency) > 1)
            {
                return 0;
            }

            decimal mode = groupedPrices.First(g => g.Count() == maxFrequency).Key;
            return mode;
        }

        public static decimal Range(IEnumerable<decimal> prices)
        {
            decimal[] pricesArray = prices.ToArray();

            return pricesArray.Max() - pricesArray.Min();
        }

        public static decimal Variance(IEnumerable<decimal> prices)
        {
            decimal[] pricesArray = prices.ToArray();
            decimal mean = pricesArray.Average();

            decimal variance = pricesArray.Select(x => (decimal)Math.Pow((double)(x - mean), 2)).Average();
            decimal standardDeviation = (decimal)Math.Sqrt((double)variance);
            decimal coefficientOfVariation = standardDeviation / mean;

            return coefficientOfVariation;
        }
    }
}
