using DirtX.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace DirtX.Infrastructure.Data
{
    public class InfrastructureDbContext : DbContext
    {
        public InfrastructureDbContext(DbContextOptions<InfrastructureDbContext> options) : base(options) {}

        public DbSet<Fitment> Fitments { get; set; }
        public DbSet<Oil> Oils { get; set; }
        public DbSet<Part> Parts { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<RidingGear> RidingGears { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }


}
