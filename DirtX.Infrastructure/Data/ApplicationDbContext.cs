using DirtX.Infrastructure.Data.Models;
using DirtX.Infrastructure.Data.Models.Mappings;
using DirtX.Infrastructure.Data.Models.Motorcycles;
using DirtX.Infrastructure.Data.Models.Products;
using DirtX.Infrastructure.Data.Models.Trailers;
using DirtX.Infrastructure.Data.Models.Users;
using DirtX.Infrastructure.Data.Seeders;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DirtX.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
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
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductBrand> ProductBrands { get; set; }
        public DbSet<Specification> Specifications { get; set; }
        public DbSet<SpecificationTitle> SpecificationTitles { get; set; }
        
        // TRAILER AND TRAILER RENT TABLES
        public DbSet<Trailer> Trailers { get; set; }
        public DbSet<TrailerRent> TrailersRents { get; set; }

        // USER-SPECIFIC AND RETAIL TABLES
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Garage> Garages { get; set; }
        public DbSet<Order> Orders { get; set; }

        // MAPPING/JUNCTION TABLES
        public DbSet<MotorcycleProduct> MotorcyclesParts { get; set; }
        public DbSet<ProductSpecification> ProductsSpecifications { get; set; }
        public DbSet<CartProduct> CartsProducts { get; set; }
        public DbSet<Wishlist> Wishlists { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=DirtX.Test;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

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

            modelBuilder.Entity<Wishlist>()
                .HasKey(w => new { w.UserId, w.ProductId });

            modelBuilder.Entity<Garage>()
                .HasKey(g => g.UserId);

            modelBuilder.Entity<Garage>()
                .HasOne(g => g.User)
                .WithOne(u => u.Garage)
                .HasForeignKey<Garage>(g => g.UserId);

            MotorcycleSeeder.SeedMotorcycles(modelBuilder);
            ProductSeeder.SeedProducts(modelBuilder);
            ProductSpecificationSeeder.SeedProductsSpecifications(modelBuilder);
            MotorcyclePartSeeder.SeedMotorcyclesParts(modelBuilder);
        }
    }
}