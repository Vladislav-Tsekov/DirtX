using DirtX.Infrastructure.Data.Models.MotorcycleSpecs;
using Microsoft.EntityFrameworkCore;

namespace DirtX.Infrastructure.Data.Seeders
{
    public static class MotorcycleSeeder
    {
        public static void SeedMotorcycles(ModelBuilder modelBuilder)
        {
            SeedMotoMakes(modelBuilder);
            SeedMotoModels(modelBuilder);
            SeedMotoYears(modelBuilder);
            SeedMotoDisplacements(modelBuilder);

            modelBuilder.Entity<Motorcycle>().HasData(
                new Motorcycle { Id = 1, MakeId = 1, ModelId = 1, YearId = 1, DisplacementId = 1 },
                new Motorcycle { Id = 2, MakeId = 1, ModelId = 1, YearId = 2, DisplacementId = 1 },
                new Motorcycle { Id = 3, MakeId = 1, ModelId = 1, YearId = 3, DisplacementId = 3 },
                new Motorcycle { Id = 4, MakeId = 2, ModelId = 2, YearId = 4, DisplacementId = 3 },
                new Motorcycle { Id = 5, MakeId = 2, ModelId = 2, YearId = 5, DisplacementId = 3 },
                new Motorcycle { Id = 6, MakeId = 2, ModelId = 2, YearId = 6, DisplacementId = 1 },
                new Motorcycle { Id = 7, MakeId = 3, ModelId = 3, YearId = 7, DisplacementId = 3 },
                new Motorcycle { Id = 8, MakeId = 3, ModelId = 3, YearId = 8, DisplacementId = 1 },
                new Motorcycle { Id = 9, MakeId = 3, ModelId = 3, YearId = 9, DisplacementId = 1 },
                new Motorcycle { Id = 10, MakeId = 4, ModelId = 4, YearId = 10, DisplacementId = 3 },
                new Motorcycle { Id = 11, MakeId = 4, ModelId = 4, YearId = 11, DisplacementId = 1 },
                new Motorcycle { Id = 12, MakeId = 4, ModelId = 4, YearId = 12, DisplacementId = 3 },
                new Motorcycle { Id = 13, MakeId = 5, ModelId = 5, YearId = 13, DisplacementId = 1 },
                new Motorcycle { Id = 14, MakeId = 5, ModelId = 5, YearId = 14, DisplacementId = 2 },
                new Motorcycle { Id = 15, MakeId = 5, ModelId = 5, YearId = 15, DisplacementId = 3 },
                new Motorcycle { Id = 16, MakeId = 6, ModelId = 6, YearId = 16, DisplacementId = 1 },
                new Motorcycle { Id = 17, MakeId = 6, ModelId = 6, YearId = 17, DisplacementId = 1 },
                new Motorcycle { Id = 18, MakeId = 6, ModelId = 6, YearId = 18, DisplacementId = 3 },
                new Motorcycle { Id = 19, MakeId = 7, ModelId = 7, YearId = 19, DisplacementId = 1 },
                new Motorcycle { Id = 20, MakeId = 7, ModelId = 7, YearId = 20, DisplacementId = 3 }
            );
        }

        private static void SeedMotoMakes(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MotoMake>().HasData(
                new MotoMake { Id = 1, Make = "Yamaha" },
                new MotoMake { Id = 2, Make = "Honda" },
                new MotoMake { Id = 3, Make = "Suzuki" },
                new MotoMake { Id = 4, Make = "Kawasaki" },
                new MotoMake { Id = 5, Make = "KTM" },
                new MotoMake { Id = 6, Make = "Husqvarna" },
                new MotoMake { Id = 7, Make = "GASGAS" }
            );
        }

        private static void SeedMotoModels(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MotoModel>().HasData(
                new MotoModel { Id = 1, Model = "YZ-F" },
                new MotoModel { Id = 2, Model = "CRF" },
                new MotoModel { Id = 3, Model = "RM-Z" },
                new MotoModel { Id = 4, Model = "KX-F" },
                new MotoModel { Id = 5, Model = "SX-F" },
                new MotoModel { Id = 6, Model = "FC" },
                new MotoModel { Id = 7, Model = "MC-F" }
            );
        }

        private static void SeedMotoYears(ModelBuilder modelBuilder)
        {
            List<MotoYear> years = Enumerable.Range(2005, 20)
                                  .Select(year => new MotoYear { Id = year - 2004, Year = year })
                                  .ToList();

            modelBuilder.Entity<MotoYear>().HasData(years);
        }

        private static void SeedMotoDisplacements(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MotoDisplacement>().HasData(
                new MotoDisplacement { Id = 1, Displacement = 250 },
                new MotoDisplacement { Id = 2, Displacement = 350 },
                new MotoDisplacement { Id = 3, Displacement = 450 }
            );
        }
    }
}
