using DirtX.Infrastructure.Data.Models;
using DirtX.Infrastructure.Data.Models.Motorcycles;
using DirtX.Infrastructure.Data.Models.Products;
using DirtX.Infrastructure.Data.Seeders;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DirtX.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        //TODO - ADD COMMENTS TO THE DB ELEMENTS
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}

        // MOTORCYCLE AND MOTORCYCLE RELATED TABLES
        public DbSet<Motorcycle> Motorcycles { get; set; }
        public DbSet<UsedMotorcycle> UsedMotorcycles { get; set; }
        public DbSet<Make>  Makes { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Year> Years { get; set; }
        public DbSet<Displacement> Displacements { get; set; }

        // PRODUCTS AND PRODUCT'S SPECIFICATIONS/PROPERTIES
        public DbSet<Part> Parts { get; set; }
        public DbSet<Oil> Oils { get; set; }
        public DbSet<Gear> Gears { get; set; }
        public DbSet<ProductBrand> ProductBrands { get; set; }
        public DbSet<ProductProperty> ProductProperties { get; set; }
        public DbSet<PropertyTitle> PropertyTitles { get; set; }

        // MAPPING/JUNCTION TABLES
        public DbSet<MotorcyclePart> MotorcyclesParts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)
            //{
            //    optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=DirtX.Test;Integrated Security=True");
            //}
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Motorcycle>()
                        .HasIndex(m => new { m.MakeId, m.ModelId, m.YearId, m.DisplacementId })
                        .IsUnique(false);

            modelBuilder.Entity<MotorcyclePart>()
                        .HasKey(mp => new { mp.MotorcycleId, mp.PartId });    

            MotorcycleSeeder.SeedMotorcycles(modelBuilder);
            ProductSeeder.SeedProducts(modelBuilder);
            MappingTableSeeder.SeedMappingTables(modelBuilder);
        }
    }
}