using DirtX.Infrastructure.Data.Models;
using DirtX.Infrastructure.Data.Models.Mappings;
using DirtX.Infrastructure.Data.Models.Motorcycles;
using DirtX.Infrastructure.Data.Models.Products;
using DirtX.Infrastructure.Data.Models.Users;
using DirtX.Infrastructure.Data.Seeders;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DirtX.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        // MOTORCYCLE AND MOTORCYCLE RELATED TABLES
        public DbSet<Motorcycle> Motorcycles { get; set; }
        public DbSet<UsedMotorcycle> UsedMotorcycles { get; set; }
        public DbSet<Make> Makes { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Year> Years { get; set; }
        public DbSet<Displacement> Displacements { get; set; }

        // PRODUCTS AND PRODUCT'S SPECIFICATIONS/PROPERTIES
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductBrand> ProductBrands { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Specification> Specifications { get; set; }

        // CARTS AND ORDERS TABLES
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Order> Orders { get; set; }

        // MAPPING/JUNCTION TABLES
        public DbSet<MotorcycleProduct> MotorcyclesParts { get; set; }
        public DbSet<ProductSpecification> ProductsSpecifications { get; set; }
        public DbSet<CartProduct> CartsProducts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=DirtX;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //TODO - IS THIS REALLY NECESSARY?
            modelBuilder.Entity<AppUser>().ToTable("AspNetUsers");

            modelBuilder.Entity<Motorcycle>()
                .HasIndex(m => new { m.MakeId, m.ModelId, m.YearId, m.DisplacementId })
                .IsUnique(false);

            modelBuilder.Entity<MotorcycleProduct>()
                .HasKey(mp => new { mp.MotorcycleId, mp.ProductId });

            modelBuilder.Entity<ProductSpecification>()
                .HasKey(ps => new { ps.ProductId, ps.SpecificationId });

            modelBuilder.Entity<CartProduct>()
                .HasKey(cp => new { cp.CartId, cp.ProductId });

            ProductSeeder.SeedProducts(modelBuilder);
            MotorcycleSeeder.SeedMotorcycles(modelBuilder);
            ProductSpecificationSeeder.SeedProductsSpecifications(modelBuilder);
            MotorcyclePartSeeder.SeedMotorcyclesParts(modelBuilder);
        }
    }
}