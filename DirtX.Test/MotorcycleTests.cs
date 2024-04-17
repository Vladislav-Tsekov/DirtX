using DirtX.Core.Services;
using DirtX.Infrastructure.Data;
using DirtX.Infrastructure.Data.Models.Motorcycles;
using Microsoft.EntityFrameworkCore;

namespace DirtX.Test
{
    public class MotorcycleTests
    {
        [Test]
        public async Task GetAllMotorcyclesAsyncReturnsAllMotorcycles()
        {

            var motorcycles = new List<Motorcycle>
            {
                new Motorcycle
                {
                    Id = 1,
                    Make = new Make { Id = 1, Title = "Honda" },
                    Model = new Model { Id = 1, Title = "CR-F" },
                    Year = new Year { Id = 1, ManufactureYear = 2020 },
                    Displacement = new Displacement { Id = 1, Volume = 450 }
                },
                new Motorcycle
                {
                    Id = 2,
                    Make = new Make { Id = 2, Title = "Yamaha" },
                    Model = new Model { Id = 2, Title = "YZF" },
                    Year = new Year { Id = 2, ManufactureYear = 2021 },
                    Displacement = new Displacement { Id = 2, Volume = 250 }
                }
            };

            var contextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "DirtXTest")
                .Options;

            using (var context = new ApplicationDbContext(contextOptions))
            {
                context.Motorcycles.AddRange(motorcycles);
                await context.SaveChangesAsync();
            }

            using (var context = new ApplicationDbContext(contextOptions))
            {
                var motorcycleService = new MotorcycleService(context);

                var result = await motorcycleService.GetAllMotorcyclesAsync();

                Assert.That(result, Is.Not.Null);
                Assert.That(result.Count, Is.EqualTo(motorcycles.Count));

                foreach (var expectedMotorcycle in motorcycles)
                {
                    var actualMotorcycle = result.FirstOrDefault(m => m.Id == expectedMotorcycle.Id);
                    Assert.That(actualMotorcycle, Is.Not.Null);
                    Assert.That(actualMotorcycle.Make.Title, Is.EqualTo(expectedMotorcycle.Make.Title));
                    Assert.That(actualMotorcycle.Model.Title, Is.EqualTo(expectedMotorcycle.Model.Title));
                    Assert.That(actualMotorcycle.Year.ManufactureYear, Is.EqualTo(expectedMotorcycle.Year.ManufactureYear));
                    Assert.That(actualMotorcycle.Displacement.Volume, Is.EqualTo(expectedMotorcycle.Displacement.Volume));
                }
            }
        }

        [Test]
        public async Task GetAllUsedMotorcyclesAsyncReturnsAllUsedMotorcycles()
        {
            var usedMotorcycles = new List<UsedMotorcycle>
            {
                new UsedMotorcycle
                {
                    Id = 1,
                    Make = new Make { Id = 55, Title = "Honda" },
                    Model = new Model { Id = 55, Title = "CR-F" },
                    Year = new Year { Id = 55, ManufactureYear = 2020 },
                    Displacement = new Displacement { Id = 55, Volume = 450 },
                    Contact = "08888888",
                    Description = "Aqwe poi asd lkjh qwempas dmpqw lorem ipsuym mipsum"
                },
                new UsedMotorcycle
                {
                    Id = 2,
                    Make = new Make { Id = 77, Title = "Yamaha" },
                    Model = new Model { Id = 77, Title = "YZF" },
                    Year = new Year { Id = 77, ManufactureYear = 2021 },
                    Displacement = new Displacement { Id = 77, Volume = 250 },
                    Contact = "08888888",
                    Description = "Aqwe poi asd lkjh qwempas dmpqw lorem ipsuym mipsum"
                }
            };

            var contextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "DirtXTest")
                .Options;

            using (var context = new ApplicationDbContext(contextOptions))
            {
                context.UsedMotorcycles.AddRange(usedMotorcycles);
                await context.SaveChangesAsync();
            }

            using (var context = new ApplicationDbContext(contextOptions))
            {
                var motorcycleService = new MotorcycleService(context);

                var result = await motorcycleService.GetAllUsedMotorcyclesAsync();

                Assert.That(result, Is.Not.Null);
                Assert.That(result.Count, Is.EqualTo(usedMotorcycles.Count));

                foreach (var expectedUsedMotorcycle in usedMotorcycles)
                {
                    var actualUsedMotorcycle = result.FirstOrDefault(um => um.Id == expectedUsedMotorcycle.Id);
                    Assert.That(actualUsedMotorcycle, Is.Not.Null);
                    Assert.That(actualUsedMotorcycle.Make.Title, Is.EqualTo(expectedUsedMotorcycle.Make.Title));
                    Assert.That(actualUsedMotorcycle.Model.Title, Is.EqualTo(expectedUsedMotorcycle.Model.Title));
                    Assert.That(actualUsedMotorcycle.Year.ManufactureYear, Is.EqualTo(expectedUsedMotorcycle.Year.ManufactureYear));
                    Assert.That(actualUsedMotorcycle.Displacement.Volume, Is.EqualTo(expectedUsedMotorcycle.Displacement.Volume));
                }
            }
        }
    }
}
