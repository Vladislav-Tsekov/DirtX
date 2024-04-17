using DirtX.Core.Models.Admin;
using DirtX.Core.Services;
using DirtX.Infrastructure.Data;
using DirtX.Infrastructure.Data.Models.Enums;
using DirtX.Infrastructure.Data.Models.Products;
using Microsoft.EntityFrameworkCore;

namespace DirtX.Test
{
    public class ProductTests
    {
        private DbContextOptions<ApplicationDbContext> options;

        [SetUp]
        public void Setup()
        {
            options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=DirtX;Integrated Security=True")
                .Options;


            using var context = new ApplicationDbContext(options);
            context.Database.Migrate();
        }

        [Test]
        public async Task GetProductAsyncWithValidIdReturnsProduct()
        {
            using var context = new ApplicationDbContext(options);

            var productService = new ProductService(context);

            var result = await productService.GetProductAsync(1);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Id, Is.EqualTo(1));
            Assert.That(result.Title, Is.EqualTo("High-Compression Forged Piston"));
        }

        [Test]
        public async Task GetAllPartsAsyncReturnsAllParts()
        {
            using var context = new ApplicationDbContext(options);

            var productService = new ProductService(context);

            var parts = await productService.GetAllPartsAsync();

            Assert.That(parts, Is.Not.Null);
            Assert.That(parts.Count, Is.EqualTo(27));
        }

        [Test]
        public async Task GetAllOilsAsyncReturnsAllOils()
        {
            using var context = new ApplicationDbContext(options);

            var productService = new ProductService(context);

            var oils = await productService.GetAllOilsAsync();

            Assert.That(oils, Is.Not.Null);
            Assert.That(oils.Count, Is.EqualTo(8));
        }

        [Test]
        public async Task GetAllGearsAsyncReturnsAllGears()
        {
            using var context = new ApplicationDbContext(options);

            var productService = new ProductService(context);

            var gears = await productService.GetAllGearsAsync();

            Assert.That(gears, Is.Not.Null);
            Assert.That(gears.Count, Is.EqualTo(10));
        }

        [Test]
        public async Task GetProductBrandAsyncReturnsCorrectBrand()
        {
            using var context = new ApplicationDbContext(options);

            var productService = new ProductService(context);

            string brandName = "Wiseco";
            string falseName = "False";

            var brand = await productService.GetProductBrandAsync(brandName);
            var falseBrand = await productService.GetProductBrandAsync(falseName);

            Assert.That(brand, Is.Not.Null);
            Assert.That(brand.Name, Is.EqualTo(brandName));
            Assert.That(falseBrand, Is.Null);
        }

        [Test]
        public async Task GetProductsByBrandAsyncReturnsProductsForBrand()
        {
            using var context = new ApplicationDbContext(options);

            var productService = new ProductService(context);
            var brand = new ProductBrand { Id = 1, Name = "Vertex" };

            var products = await productService.GetProductsByBrandAsync(brand);

            Assert.That(products, Is.Not.Null);
            Assert.That(products.All(p => p.BrandId == brand.Id), Is.True);
        }

        [Test]
        public async Task GetAllProductsByCategoryAsyncReturnsProductsByCategory()
        {
            using var context = new ApplicationDbContext(options);

            var productService = new ProductService(context);
            var category = ProductCategory.Engine;

            var products = await productService.GetAllProductsByCategoryAsync(category);

            Assert.That(products, Is.Not.Null);
            Assert.That(products.All(p => p.Category == category), Is.True);
        }

        [Test]
        public async Task GetDistinctProductBrandsAsyncReturnsDistinctBrands()
        {
            using var context = new ApplicationDbContext(options);

            var productService = new ProductService(context);

            var products = new List<Product>
                {
                    new Product { Id = 9, BrandId = 16, TypeId = 1, Title = "Air Filter", Price = 24.49m, Description = "Premium air filter for improved air flow and engine performance.", StockQuantity = 27, Category = ProductCategory.Filters, ImageUrl = "https://i.ibb.co/vqg672F/Product-Air-Filter.jpg" },
                    new Product { Id = 10, BrandId = 6, TypeId = 1, Title = "Oil Filter", Price = 10.99m, Description = "High-quality oil filter for efficient filtration and engine longevity.", StockQuantity = 19, Category = ProductCategory.Filters, ImageUrl = "https://i.ibb.co/kG1KnVN/Product-Product-Filter.jpg" },
                };

            var distinctBrands = await productService.GetDistinctProductBrandsAsync(products);

            Assert.That(distinctBrands, Is.Not.Null);
            Assert.That(distinctBrands.Count, Is.EqualTo(2));
        }

        [Test]
        public void GetProductCategoriesReturnsDistinctCategories()
        {
            var productService = new ProductService(null);

            var products = new List<Product>
            {
                new Product { Id = 15, BrandId = 11, TypeId = 1, Title = "Front Brake Disc", Price = 89.99m, Description = "High-performance brake disc for superior stopping power.", StockQuantity = 0, Category = ProductCategory.Braking_System, ImageUrl = "https://i.ibb.co/DG6HpM4/Product-Front-Brake-Disc.jpg" },
                new Product { Id = 16, BrandId = 11, TypeId = 1, Title = "Rear Brake Disc", Price = 77.29m, Description = "High-performance brake disc for superior stopping power.", StockQuantity = 7, Category = ProductCategory.Braking_System, ImageUrl = "https://i.ibb.co/BNPMF26/Product-Rear-Brake-Disc.jpg" },
            };

            var distinctCategories = productService.GetProductCategories(products);

            Assert.That(distinctCategories, Is.Not.Null);
            Assert.That(distinctCategories.Count, Is.EqualTo(1));
        }

        [Test]
        public async Task GetProductSpecificationsAsyncReturnsSpecificationsForProduct()
        {
            using var context = new ApplicationDbContext(options);

            var productService = new ProductService(context);
            int productId = 1;

            var specifications = await productService.GetProductSpecificationsAsync(productId);

            Assert.That(specifications, Is.Not.Null);
            Assert.That(specifications.All(s => s.ProductId == productId), Is.True);
        }

        [Test]
        public async Task GetCompatiblePartsAsyncReturnsCompatibleParts()
        {
            using var context = new ApplicationDbContext(options);

            var productService = new ProductService(context);
            int makeId = 1;
            int modelId = 1;
            int displacementId = 1;
            int yearId = 1;

            var compatibleParts = await productService.GetCompatiblePartsAsync(makeId, modelId, displacementId, yearId);

            Assert.That(compatibleParts, Is.Not.Null);
        }

        [Test]
        public async Task GetAllProductsAsyncReturnsAllProducts()
        {
            using var context = new ApplicationDbContext(options);

            var productService = new ProductService(context);

            var products = await productService.GetAllProductsAsync();

            Assert.That(products, Is.Not.Null);

            Assert.That(products.All(p => !string.IsNullOrEmpty(p.Title)), Is.True);
            Assert.That(products.All(p => !string.IsNullOrEmpty(p.Description)), Is.True);
            Assert.That(products.All(p => !string.IsNullOrEmpty(p.ImageUrl)), Is.True);
            Assert.That(products.Select(p => p.Price), Is.Not.Zero);
        }

        [Test]
        public async Task AddProductAsyncAddsProductToDatabase()
        {
            using var context = new ApplicationDbContext(options);

            using (var transaction = context.Database.BeginTransaction())
            {
                var productService = new ProductService(context);
                var model = new ProductFormViewModel
                {
                    BrandId = 1,
                    TypeId = 1,
                    Category = ProductCategory.Engine,
                    Title = "Test Product",
                    Description = "Test Description Test Description",
                    Price = 100,
                    StockQuantity = 10,
                    ImageUrl = "testimage.jpg"
                };

                await productService.AddProductAsync(model);

                var addedProduct = await context.Products.FirstOrDefaultAsync(p => p.Title == model.Title);
                Assert.That(addedProduct, Is.Not.Null);
                Assert.That(addedProduct.BrandId, Is.EqualTo(model.BrandId));
                Assert.That(addedProduct.TypeId, Is.EqualTo(model.TypeId));
                Assert.That(addedProduct.Category, Is.EqualTo(model.Category));
                Assert.That(addedProduct.Description, Is.EqualTo(model.Description));
                Assert.That(addedProduct.Price, Is.EqualTo(model.Price));
                Assert.That(addedProduct.StockQuantity, Is.EqualTo(model.StockQuantity));
                Assert.That(addedProduct.ImageUrl, Is.EqualTo(model.ImageUrl));

                transaction.Rollback();
            }
        }

        [Test]
        public async Task EditProductAsyncEditsExistingProduct()
        {
            using var context = new ApplicationDbContext(options);

            using (var transaction = context.Database.BeginTransaction())
            {
                var productService = new ProductService(context);
                int productId = 10;
                var model = new ProductFormViewModel
                {
                    Title = "Updated Title",
                    Description = "Updated Description",
                    Price = 200,
                    ImageUrl = "updatedimage.jpg",
                    StockQuantity = 20,
                    BrandId = 2,
                    TypeId = 2,
                    Category = ProductCategory.Accessory
                };

                await productService.EditProductAsync(productId, model);

                var editedProduct = await context.Products.FindAsync(productId);
                Assert.That(editedProduct, Is.Not.Null);
                Assert.That(editedProduct.Title, Is.EqualTo(model.Title));
                Assert.That(editedProduct.Description, Is.EqualTo(model.Description));
                Assert.That(editedProduct.Price, Is.EqualTo(model.Price));
                Assert.That(editedProduct.ImageUrl, Is.EqualTo(model.ImageUrl));
                Assert.That(editedProduct.StockQuantity, Is.EqualTo(model.StockQuantity));
                Assert.That(editedProduct.BrandId, Is.EqualTo(model.BrandId));
                Assert.That(editedProduct.TypeId, Is.EqualTo(model.TypeId));
                Assert.That(editedProduct.Category, Is.EqualTo(model.Category));

                transaction.Rollback();
            }
        }


        [Test]
        public async Task DeleteProductAsyncDeletesExistingProduct()
        {
            using var context = new ApplicationDbContext(options);

            using (var transaction = context.Database.BeginTransaction())
            {
                var productService = new ProductService(context);
                int productId = 25;

                await productService.DeleteProductAsync(productId);

                var deletedProduct = await context.Products.FindAsync(productId);
                Assert.That(deletedProduct, Is.Null);

                transaction.Rollback();
            }
        }


        [Test]
        public async Task GetAllProductBrandsAsyncReturnsAllProductBrands()
        {
            using var context = new ApplicationDbContext(options);

            var productService = new ProductService(context);

            var productBrands = await productService.GetAllProductBrandsAsync();

            Assert.That(productBrands, Is.Not.Null);
            Assert.That(productBrands.Count, Is.GreaterThan(0));
        }

        [Test]
        public async Task GetAllProductTypesAsyncReturnsAllProductTypes()
        {
            using var context = new ApplicationDbContext(options);

            var productService = new ProductService(context);

            var productTypes = await productService.GetAllProductTypesAsync();

            Assert.That(productTypes, Is.Not.Null);
            Assert.That(productTypes.Count, Is.GreaterThan(0));
        }

        [Test]
        public async Task GetAllSpecificationsAsyncReturnsAllSpecifications()
        {
            using var context = new ApplicationDbContext(options);

            var productService = new ProductService(context);

            var specifications = await productService.GetAllSpecificationsAsync();

            Assert.That(specifications, Is.Not.Null);

            Assert.That(specifications.Count, Is.GreaterThan(0));
        }

        [Test]
        public async Task AddProductBrandAsyncAddsProductBrandToDatabase()
        {
            using (var context = new ApplicationDbContext(options))
            {
                using var transaction = await context.Database.BeginTransactionAsync();

                var productService = new ProductService(context);
                var model = new BrandFormViewModel
                {
                    Name = "Test Brand",
                    Description = "Test Description",
                    ImageUrl = "testimage.jpg"
                };

                await productService.AddProductBrandAsync(model);

                var addedBrand = await context.ProductBrands.FirstOrDefaultAsync(b => b.Name == "Test Brand");
                Assert.That(addedBrand.Name, Is.EqualTo(addedBrand.Name));

                await transaction.RollbackAsync();
            }
        }

        [Test]
        public async Task AddSpecificationAsyncAddsSpecificationToDatabase()
        {
            using (var context = new ApplicationDbContext(options))
            {
                using var transaction = await context.Database.BeginTransactionAsync();

                var productService = new ProductService(context);
                var model = new SpecificationFormViewModel
                {
                    Title = "Test Specification",
                    Value = "Test Value"
                };

                await productService.AddSpecificationAsync(model);

                var addedSpecification = await context.Specifications.FirstOrDefaultAsync(s => s.Title == "Test Specification");
                Assert.That(addedSpecification.Title, Is.EqualTo(addedSpecification.Title));

                await transaction.RollbackAsync();
            }
        }
    }
}
