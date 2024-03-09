using DirtX.Scraper.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace DirtX.Scraper.Data
{
    public class ScraperDbContext : DbContext
    {
        public ScraperDbContext(DbContextOptions<ScraperDbContext> options) : base(options) { }

        public DbSet<Motorcycle> Motorcycles { get; set; }
        public DbSet<Make> Makes { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Year> Years { get; set; }
        public DbSet<Displacement> Displacements { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=DirtX.Scraper.Test;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //FOR MAPPING TABLES, COMPOSITE FKs, SEED DATA

            base.OnModelCreating(modelBuilder);
        }
    }
}
