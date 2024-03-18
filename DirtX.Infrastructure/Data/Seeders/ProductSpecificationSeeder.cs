using DirtX.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace DirtX.Infrastructure.Data.Seeders
{
    public static class ProductSpecificationSeeder
    {
        public static void SeedProductsSpecifications(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductSpecification>().HasData(
                new ProductSpecification { ProductId = 1, SpecificationId = 1 },
                new ProductSpecification { ProductId = 1, SpecificationId = 8 },
                new ProductSpecification { ProductId = 1, SpecificationId = 17 },
                new ProductSpecification { ProductId = 2, SpecificationId = 1 },
                new ProductSpecification { ProductId = 2, SpecificationId = 7 },
                new ProductSpecification { ProductId = 2, SpecificationId = 19 },
                new ProductSpecification { ProductId = 3, SpecificationId = 2 },
                new ProductSpecification { ProductId = 3, SpecificationId = 15 },
                new ProductSpecification { ProductId = 4, SpecificationId = 15 },
                new ProductSpecification { ProductId = 5, SpecificationId = 6 },
                new ProductSpecification { ProductId = 5, SpecificationId = 16 },
                new ProductSpecification { ProductId = 6, SpecificationId = 9 }
                ); 

            //TODO - FILL WITH MORE DATA
        }
    }
}
