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
                new ProductSpecification { ProductId = 6, SpecificationId = 9 },
                new ProductSpecification { ProductId = 7, SpecificationId = 2 },
                new ProductSpecification { ProductId = 9, SpecificationId = 3 },
                new ProductSpecification { ProductId = 9, SpecificationId = 14 },
                new ProductSpecification { ProductId = 11, SpecificationId = 1 },
                new ProductSpecification { ProductId = 11, SpecificationId = 3 },
                new ProductSpecification { ProductId = 11, SpecificationId = 16 },
                new ProductSpecification { ProductId = 12, SpecificationId = 13 },
                new ProductSpecification { ProductId = 13, SpecificationId = 4 },
                new ProductSpecification { ProductId = 14, SpecificationId = 1 },
                new ProductSpecification { ProductId = 14, SpecificationId = 15 },
                new ProductSpecification { ProductId = 15, SpecificationId = 6 },
                new ProductSpecification { ProductId = 15, SpecificationId = 26 },
                new ProductSpecification { ProductId = 16, SpecificationId = 6 },
                new ProductSpecification { ProductId = 16, SpecificationId = 25 },
                new ProductSpecification { ProductId = 17, SpecificationId = 24 },
                new ProductSpecification { ProductId = 18, SpecificationId = 23 },
                new ProductSpecification { ProductId = 19, SpecificationId = 27 },
                new ProductSpecification { ProductId = 20, SpecificationId = 24 },
                new ProductSpecification { ProductId = 21, SpecificationId = 6 },
                new ProductSpecification { ProductId = 24, SpecificationId = 1 },
                new ProductSpecification { ProductId = 25, SpecificationId = 1 },
                new ProductSpecification { ProductId = 27, SpecificationId = 4 },
                new ProductSpecification { ProductId = 27, SpecificationId = 6 },
                new ProductSpecification { ProductId = 29, SpecificationId = 31 },
                new ProductSpecification { ProductId = 30, SpecificationId = 30 },
                new ProductSpecification { ProductId = 31, SpecificationId = 29 },
                new ProductSpecification { ProductId = 33, SpecificationId = 30 },
                new ProductSpecification { ProductId = 35, SpecificationId = 30 },
                new ProductSpecification { ProductId = 36, SpecificationId = 10 },
                new ProductSpecification { ProductId = 38, SpecificationId = 16 },
                new ProductSpecification { ProductId = 39, SpecificationId = 16 },
                new ProductSpecification { ProductId = 40, SpecificationId = 9 },
                new ProductSpecification { ProductId = 40, SpecificationId = 10 },
                new ProductSpecification { ProductId = 40, SpecificationId = 15 },
                new ProductSpecification { ProductId = 40, SpecificationId = 32 },
                new ProductSpecification { ProductId = 41, SpecificationId = 12 },
                new ProductSpecification { ProductId = 41, SpecificationId = 15 },
                new ProductSpecification { ProductId = 41, SpecificationId = 32 },
                new ProductSpecification { ProductId = 43, SpecificationId = 16 },
                new ProductSpecification { ProductId = 44, SpecificationId = 12 },
                new ProductSpecification { ProductId = 45, SpecificationId = 10 }
            ); 
        }
    }
}
