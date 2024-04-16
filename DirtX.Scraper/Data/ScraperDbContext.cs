using DirtX.Scraper.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace DirtX.Scraper.Data
{
    public class ScraperDbContext : DbContext
    {
        public ScraperDbContext(DbContextOptions<ScraperDbContext> options) : base(options) { }

        public DbSet<Make> Makes { get; set; }
        public DbSet<Year> Years { get; set; }
        public DbSet<Motorcycle> Motorcycles { get; set; }
        public DbSet<SoldMotorcycle> SoldMotorcycles { get; set; }
        public DbSet<MotorcycleMarketPrice> MarketPrices { get; set; }
        public DbSet<ScraperInfo> ScraperInfo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MotorcycleMarketPrice>(e => e.HasKey(mp => new { mp.MakeId, mp.YearId }));
        }
    }
}
