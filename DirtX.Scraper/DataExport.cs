using DirtX.Calculations;
using DirtX.Scraper.Data;
using DirtX.Scraper.Data.Models;
using DirtX.Scraper.Models;
using DirtX.Scraper.Shared;
using Microsoft.EntityFrameworkCore;
using static DirtX.Scraper.Shared.Constants;

namespace DirtX.Scraper
{
    public static class DataExport
    {
        public static async Task UpdateMakesTable(List<string> distinctMakes, ScraperDbContext context)
        {
            List<string> existingMakes = await context.Makes.Select(m => m.Title).ToListAsync();
            HashSet<Make> makesToAdd = new();

            foreach (var make in distinctMakes)
            {
                if (!existingMakes.Contains(make))
                {
                    Make currentMake = new() { Title = make };
                    makesToAdd.Add(currentMake);
                }
            }

            if (makesToAdd.Count > 0)
            {
                await context.Makes.AddRangeAsync(makesToAdd);
                await context.SaveChangesAsync();
            }
        }

        public static async Task UpdateYearsTable(List<int> distinctYears, ScraperDbContext context)
        {
            List<int> existingYears = await context.Years.Select(m => m.ManufactureYear).ToListAsync();
            HashSet<Year> yearsToAdd = new();

            foreach (var year in distinctYears)
            {
                if (!existingYears.Contains(year))
                {
                    Year currentYear = new() { ManufactureYear = (year) };
                    yearsToAdd.Add(currentYear);
                }
            }

            if (yearsToAdd.Count > 0)
            {
                await context.Years.AddRangeAsync(yearsToAdd);
                await context.SaveChangesAsync();
            }
        }

        public static async Task AddMotorcycleEntries(ICollection<ScrapeMotorcycle> scrapedMoto, ScraperDbContext context, ScraperSettings settings)
        {
            using StreamWriter motoWriter = new(Path.Combine(settings.GetScraperOutputDirectory(), AllLinksCsv));
            motoWriter.WriteLine(AllLinksTitles);

            List<Motorcycle> dbEntries = await context.Motorcycles.ToListAsync();

            HashSet<Motorcycle> entries = new();
            HashSet<Motorcycle> existingMotorcycles = new(dbEntries);

            foreach (var moto in scrapedMoto)
            {
                Make make = await context.Makes.FirstOrDefaultAsync(m => m.Title == moto.Make);
                Year year = await context.Years.FirstOrDefaultAsync(y => y.ManufactureYear == moto.Year);

                if (make is null || year is null)
                {
                    continue;
                }

                motoWriter.WriteLine(String.Format(AllLinksMotoInfo, moto.Make, moto.Displacement, moto.Year, moto.Price, moto.Link));

                if (!dbEntries.Any(e => e.Link == moto.Link))
                {
                    Motorcycle entry = new()
                    {
                        Make = make,
                        Year = year,
                        Displacement = moto.Displacement,
                        Price = moto.Price,
                        Link = moto.Link,
                        DateAdded = DateTime.Now
                    };

                    entries.Add(entry);
                }
                else
                {
                    Motorcycle currentMoto = existingMotorcycles.FirstOrDefault(e => e.Link == moto.Link);

                    if (currentMoto is not null)
                    {
                        if (currentMoto.Price != moto.Price)
                        {
                            currentMoto.OldPrice = currentMoto.Price;
                            currentMoto.Price = moto.Price;
                            currentMoto.PriceChanges += 1;
                        }
                    }
                }
            }

            motoWriter.Dispose();

            foreach (var existingEntry in dbEntries)
            {
                if (!scrapedMoto.Any(m => m.Link == existingEntry.Link))
                {
                    existingEntry.IsSold = true;
                }
            }

            await context.Motorcycles.AddRangeAsync(entries);
            await context.SaveChangesAsync();
        }

        public static async Task AddMarketPrices(ICollection<ScrapeMotorcycle> filteredMoto, ScraperDbContext context, ScraperSettings settings)
        {
            var averagePrices = filteredMoto
            .GroupBy(m => new { m.Make, m.Year })
            .Select(group => new
            {
                group.Key.Make,
                group.Key.Year,
                AveragePrice = group.Average(m => m.Price),
                MeanPrice = MeanValues.MeanTrim(group.Select(m => m.Price)),
                DevPrice = MeanValues.StdDev(group.Select(m => m.Price)),
                MedianPrice = MeanValues.Median(group.Select(m => m.Price)),
                ModePrice = MeanValues.Mode(group.Select(m => m.Price)),
                PriceVariance = MeanValues.Variance(group.Select(m => m.Price)),
                PriceRange = MeanValues.Range(group.Select(m => m.Price)),
                MotorcycleCount = group.Count(),
            })
            .OrderBy(m => m.Make)
            .ThenBy(m => m.Year)
            .ThenBy(m => m.AveragePrice)
            .ToList();

            StreamWriter priceWriter = new(Path.Combine(settings.GetScraperOutputDirectory(), MarketPriceCsv));
            priceWriter.WriteLine(MarketPriceTitles);

            HashSet<MotorcycleMarketPrice> marketPrices = new();

            foreach (var m in averagePrices)
            {
                MotorcycleMarketPrice motoExists = context.MarketPrices
                    .FirstOrDefault(record => record.Make.Title == m.Make
                                 && record.Year.ManufactureYear == m.Year);

                if (motoExists is not null)
                {
                    motoExists.AvgPrice = (decimal)m.AveragePrice;
                    motoExists.MeanTrimPrice = (decimal)m.MeanPrice;
                    motoExists.StdDevPrice = (decimal)m.DevPrice;
                    motoExists.MedianPrice = (decimal)m.MedianPrice;
                    motoExists.ModePrice = (decimal)m.ModePrice;
                    motoExists.PriceVariance = (decimal)m.PriceVariance;
                    motoExists.PriceRange = (decimal)m.PriceRange;
                    motoExists.MotoCount = m.MotorcycleCount;
                }
                else
                {
                    Make make = context.Makes.FirstOrDefault(mExists => mExists.Title == m.Make);
                    Year year = context.Years.FirstOrDefault(yExists => yExists.ManufactureYear == m.Year);

                    MotorcycleMarketPrice mmp = new()
                    {
                        Make = make,
                        Year = year,
                        AvgPrice = (decimal)m.AveragePrice,
                        MeanTrimPrice = (decimal)m.MeanPrice,
                        StdDevPrice = (decimal)m.DevPrice,
                        MedianPrice = (decimal)m.MedianPrice,
                        ModePrice = (decimal)m.ModePrice,
                        PriceVariance = (decimal)m.PriceVariance,
                        PriceRange = (decimal)m.PriceRange,
                        MotoCount = m.MotorcycleCount,
                    };

                    marketPrices.Add(mmp);
                }

                priceWriter.WriteLine(String.Format(MarketPriceMotoInfo,
                                                    m.Make,
                                                    m.Year,
                                                    m.MotorcycleCount,
                                                    m.AveragePrice,
                                                    m.MeanPrice,
                                                    m.DevPrice,
                                                    m.MedianPrice,
                                                    m.PriceVariance));
            }

            priceWriter.Dispose();

            await context.MarketPrices.AddRangeAsync(marketPrices);
            await context.SaveChangesAsync();
        }

        public static async Task TransferSoldEntries(ScraperDbContext context)
        {
            var dbEntries = await context.Motorcycles.Where(e => e.IsSold == true).ToListAsync();

            HashSet<Motorcycle> soldEntries = new(dbEntries);
            HashSet<SoldMotorcycle> transferEntries = new();

            foreach (var moto in soldEntries)
            {
                Make newMake = new();
                Year newYear = new();

                newMake = await context.Makes.FindAsync(moto.MakeId);
                newYear = await context.Years.FindAsync(moto.YearId);

                SoldMotorcycle newSoldEntry = new()
                {
                    Make = newMake,
                    Year = newYear,
                    Displacement = moto.Displacement,
                    Price = moto.Price,
                    DateAdded = moto.DateAdded,
                    DateSold = DateTime.Now
                };

                if (newSoldEntry.Make is not null && newSoldEntry.Year is not null)
                {
                    transferEntries.Add(newSoldEntry);
                }
            }

            context.Motorcycles.RemoveRange(soldEntries);

            await context.SoldMotorcycles.AddRangeAsync(transferEntries);
            await context.SaveChangesAsync();
        }
    }
}

