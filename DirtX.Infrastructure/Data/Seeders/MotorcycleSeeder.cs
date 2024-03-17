using DirtX.Infrastructure.Data.Models.Enums;
using DirtX.Infrastructure.Data.Models.Motorcycles;
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
            SeedAvailableMotorcycles(modelBuilder);
            SeedUsedMotorcycles(modelBuilder);
        }

        private static void SeedUsedMotorcycles(ModelBuilder modelBuilder)
        {
            string currentDir = Directory.GetCurrentDirectory();
            string parentDir = Directory.GetParent(currentDir).FullName;

            string ktmImagePath = Path.Combine(parentDir, @"DirtX.Infrastructure\Data\Seeders\Images\ktm.jpg");
            string yamahaImagePath = Path.Combine(parentDir, @"DirtX.Infrastructure\Data\Seeders\Images\yamaha.jpg");

            byte[] ktmImage = File.ReadAllBytes(ktmImagePath);
            byte[] yamahaImage = File.ReadAllBytes(yamahaImagePath);

            modelBuilder.Entity<UsedMotorcycle>().HasData(
                new UsedMotorcycle { Id = 1, MakeId = 1, ModelId = 1, DisplacementId = 1, YearId = 2, Price = 3200, Contact = "0885992255", Image = yamahaImage, Province = Province.Blagoevgrad, Description = "In a very good condition for its age. Leaky suspension. For more questions don't hesitate to call me!" },
                new UsedMotorcycle { Id = 2, MakeId = 5, ModelId = 5, DisplacementId = 3, YearId = 15, Price = 9800, Contact = "0892557711", Image = ktmImage, Province = Province.Sofia_Province, Description = "Oil and filters changes 5h ago. Excellent bike for beginners. Get in touch if you want to see more pictures." }
             );
        }

        private static void SeedAvailableMotorcycles(ModelBuilder modelBuilder)
        {
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

            //TODO - ADD MORE MOTORCYCLES, IF PROJECT IS FINISHED EARLY
        }

        private static void SeedMotoMakes(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Make>().HasData(
                new Make { Id = 1, Title = "Yamaha" },
                new Make { Id = 2, Title = "Honda" },
                new Make { Id = 3, Title = "Suzuki" },
                new Make { Id = 4, Title = "Kawasaki" },
                new Make { Id = 5, Title = "KTM" },
                new Make { Id = 6, Title = "Husqvarna" },
                new Make { Id = 7, Title = "GASGAS" }
            );
        }

        private static void SeedMotoModels(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Model>().HasData(
                new Model { Id = 1, Title = "YZ-F" },
                new Model { Id = 2, Title = "CRF" },
                new Model { Id = 3, Title = "RM-Z" },
                new Model { Id = 4, Title = "KX-F" },
                new Model { Id = 5, Title = "SX-F" },
                new Model { Id = 6, Title = "FC" },
                new Model { Id = 7, Title = "MC-F" }
            );
        }

        private static void SeedMotoYears(ModelBuilder modelBuilder)
        {
            List<Year> years = Enumerable.Range(2005, 20)
                                  .Select(year => new Year { Id = year - 2004, ManufactureYear = year })
                                  .ToList();

            modelBuilder.Entity<Year>().HasData(years);
        }

        private static void SeedMotoDisplacements(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Displacement>().HasData(
                new Displacement { Id = 1, Volume = 250 },
                new Displacement { Id = 2, Volume = 350 },
                new Displacement { Id = 3, Volume = 450 }
            );
        }
    }
}
