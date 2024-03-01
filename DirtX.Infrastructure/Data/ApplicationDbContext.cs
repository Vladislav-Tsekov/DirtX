using DirtX.Infrastructure.Data.Models;
using DirtX.Infrastructure.Data.Models.MotorcycleSpecs;
using DirtX.Infrastructure.Data.Models.ProductModels;
using DirtX.Infrastructure.Data.Models.ProductModels.Properties;
using DirtX.Infrastructure.Data.Seeders;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DirtX.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}

        //MOTORCYCLES
        public DbSet<Motorcycle> Motorcycles { get; set; }
        public DbSet<MotoMake> MotoMakes { get; set; }
        public DbSet<MotoModel> MotoModels { get; set; }
        public DbSet<MotoYear> MotoYears { get; set; }
        public DbSet<MotoDisplacement> MotoDisplacements { get; set; }

        //PRODUCTS AND PRODUCTS SPECIFICATIONS/PROPERTIES
        public DbSet<Part> Parts { get; set; }
        public DbSet<PartSpecification> PartSpecifications { get; set; }
        public DbSet<Oil> Oils { get; set; }
        public DbSet<OilSpecification> OilSpecifications { get; set; }
        public DbSet<Gear> Gears { get; set; }
        public DbSet<GearSpecification> GearSpecifications { get; set; }
        public DbSet<ProductBrand> ProductBrands { get; set; }

        //MAPPING/JUNCTION TABLES
        public DbSet<MotorcyclePart> MotorcyclesParts { get; set; }
        public DbSet<PartProperty> PartsProperties { get; set; }
        public DbSet<OilProperty> OilsProperties { get; set; }
        public DbSet<GearProperty> GearsProperties { get; set; }

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
            
            modelBuilder.Entity<PartProperty>()
                        .HasKey(pp => new { pp.PartId, pp.PropertyId }); 
            
            modelBuilder.Entity<OilProperty>()
                        .HasKey(op => new { op.OilId, op.PropertyId });  
            
            modelBuilder.Entity<GearProperty>()
                        .HasKey(gp => new { gp.GearId, gp.PropertyId });

            //MotorcycleSeeder.SeedMotorcycles(modelBuilder);
            //ProductSeeder.SeedProducts(modelBuilder);
        }
    }
}
