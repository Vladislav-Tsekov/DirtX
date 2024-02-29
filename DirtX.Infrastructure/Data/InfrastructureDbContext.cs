//using DirtX.Infrastructure.Data.Models;
//using DirtX.Infrastructure.Data.Models.MotorcycleSpecs;
//using DirtX.Infrastructure.Data.Models.ProductModels;
//using Microsoft.EntityFrameworkCore;

//namespace DirtX.Infrastructure.Data
//{
//    public class InfrastructureDbContext : DbContext
//    {
//        public InfrastructureDbContext(DbContextOptions<InfrastructureDbContext> options) : base(options) { }

//        public DbSet<Motorcycle> Motorcycles { get; set; }
//        public DbSet<MotoMake> MotoMakes { get; set; }
//        public DbSet<MotoModel> MotoModels { get; set; }
//        public DbSet<MotoYear> MotoYears { get; set; }
//        public DbSet<MotoDisplacement> MotoDisplacements { get; set; }
//        public DbSet<MotorcyclePart> MotorcyclesParts { get; set; }
//        public DbSet<Part> Parts { get; set; }
//        public DbSet<Oil> Oils { get; set; }
//        public DbSet<RidingGear> RidingGears { get; set; }
//        public DbSet<ProductBrand> ProductBrands { get; set; }
//        public DbSet<ProductProperty> ProductsProperties { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//                optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=MotoMarketAnalysis;Integrated Security=True");
//            }
//        }

//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {
//            modelBuilder.Entity<Motorcycle>()
//                        .HasIndex(m => new { m.MakeId, m.ModelId, m.YearId, m.DisplacementId })
//                        .IsUnique(false);

//            modelBuilder.Entity<MotorcyclePart>()
//                        .HasKey(mp => new { mp.MotorcycleId, mp.PartId });
//        }
//    }


//}
