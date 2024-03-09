﻿using DirtX.Infrastructure.Data.Models;
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
        //TODO - ADD COMMENTS TO THE DB ELEMENTS
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}

        // MOTORCYCLE AND MOTORCYCLE RELATED TABLES
        public DbSet<Motorcycle> Motorcycles { get; set; }
        public DbSet<Make>  Makes { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Year> Years { get; set; }
        public DbSet<Displacement> Displacements { get; set; }

        // PRODUCTS AND PRODUCT'S SPECIFICATIONS/PROPERTIES
        public DbSet<Part> Parts { get; set; }
        public DbSet<PartSpecification> PartsSpecifications { get; set; }
        public DbSet<Oil> Oils { get; set; }
        public DbSet<OilSpecification> OilsSpecifications { get; set; }
        public DbSet<Gear> Gears { get; set; }
        public DbSet<GearSpecification> GearsSpecifications { get; set; }
        public DbSet<ProductBrand> ProductBrands { get; set; }

        // MAPPING/JUNCTION TABLES
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
            //TODO - USE IENTITYCONFIGURATION INSTEAD MODELBUILDER?

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Motorcycle>()
                        .HasIndex(m => new { m.MakeId, m.ModelId, m.YearId, m.DisplacementId })
                        .IsUnique(false);

            modelBuilder.Entity<MotorcyclePart>()
                        .HasKey(mp => new { mp.MotorcycleId, mp.PartId });  
            
            modelBuilder.Entity<PartProperty>()
                        .HasKey(pp => new { pp.PartId, pp.SpecificationId }); 
            
            modelBuilder.Entity<OilProperty>()
                        .HasKey(op => new { op.OilId, op.SpecificationId });  
            
            modelBuilder.Entity<GearProperty>()
                        .HasKey(gp => new { gp.GearId, gp.SpecificationId });

            MotorcycleSeeder.SeedMotorcycles(modelBuilder);
            ProductSeeder.SeedProducts(modelBuilder);
            MappingTableSeeder.SeedMappingTables(modelBuilder);
        }
    }
}
