using DirtX.Infrastructure.Data.Models.Trailers;
using Microsoft.EntityFrameworkCore;
using static System.Net.WebRequestMethods;

namespace DirtX.Infrastructure.Data.Seeders
{
    public static class TrailerSeeder
    {
        public static void SeedTrailers(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Trailer>().HasData(
                new Trailer { Id = 1, CostPerDay = 30, Capacity = 1, MaximumLoad = 200, IsAvailable = true, ImageUrl = "https://i.ibb.co/3zZVXNd/capacity-1.jpg" },
                new Trailer { Id = 2, CostPerDay = 45, Capacity = 2, MaximumLoad = 450, IsAvailable = true, ImageUrl = "https://i.ibb.co/Fxnr737/capacity-2.jpg" },
                new Trailer { Id = 3, CostPerDay = 60, Capacity = 3, MaximumLoad = 750, IsAvailable = true, ImageUrl = "https://i.ibb.co/TR8jdFq/capacity-3.jpg" }
            );
        }
    }
}
