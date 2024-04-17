using DirtX.Core.Enums;
using DirtX.Core.Interfaces;
using DirtX.Core.Models;
using DirtX.Core.Models.Admin;
using DirtX.Infrastructure.Data;
using DirtX.Infrastructure.Data.Models;
using DirtX.Infrastructure.Data.Models.Enums;
using DirtX.Infrastructure.Data.Models.Mappings;
using DirtX.Infrastructure.Data.Models.Products;
using DirtX.Infrastructure.Data.Models.Users;
using Microsoft.EntityFrameworkCore;

namespace DirtX.Core.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext context;

        public ProductService(ApplicationDbContext _context)
        {
            context = _context;
        }

        public async Task<Product> GetProductAsync(int id)
        {
            return await context.Products
                .AsNoTracking()
                .Include(p => p.Brand)
                .Include(p => p.Type)
                .Include(p => p.Specifications)
                .Where(p => p.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Product>> GetAllPartsAsync()
        {
            return await context.Products
                .AsNoTracking()
                .Where(p => p.Type.Name == "Part")
                .ToListAsync();
        }

        public async Task<List<Product>> GetAllOilsAsync()
        {
            return await context.Products
                .AsNoTracking()
                .Where(p => p.Type.Name == "Oil")
                .ToListAsync();
        }

        public async Task<List<Product>> GetAllGearsAsync()
        {
            return await context.Products
                .AsNoTracking()
                .Where(p => p.Type.Name == "Gear")
                .ToListAsync();
        }

        public async Task<ProductBrand> GetProductBrandAsync(string brandName)
        {
            return await context.ProductBrands
                .AsNoTracking()
                .FirstOrDefaultAsync(b => b.Name == brandName);
        }

        public async Task<List<Product>> GetProductsByBrandAsync(ProductBrand brand)
        {
            return await context.Products
                .AsNoTracking()
                .Where(p => p.BrandId == brand.Id)
                .ToListAsync();
        }

        public async Task<List<Product>> GetAllProductsByCategoryAsync(ProductCategory category, ProductSorting sorting = ProductSorting.Name_Ascending)
        {
            IQueryable<Product> products = context.Products.Where(p => p.Category == category).AsNoTracking();

            switch (sorting)
            {
                case ProductSorting.Name_Descending:
                    products = products.OrderByDescending(o => o.Title);
                    break;
                case ProductSorting.Price_Ascending:
                    products = products.OrderBy(o => o.Price);
                    break;
                case ProductSorting.Price_Descending:
                    products = products.OrderByDescending(o => o.Price);
                    break;
                default:
                    break;
            }

            return await products.ToListAsync();
        }

        public async Task<List<ProductBrand>> GetDistinctProductBrandsAsync(List<Product> products)
        {
            List<int> distinctBrands = products
                .Select(p => p.BrandId)
                .Distinct()
                .ToList();

            return await context.ProductBrands
                .AsNoTracking()
                .Where(brand => distinctBrands.Contains(brand.Id))
                .ToListAsync();
        }

        public List<ProductCategory> GetProductCategories(List<Product> products)
        {
            return products
                .Select(p => p.Category)
                .Distinct()
                .ToList();
        }

        public async Task<List<ProductSpecification>> GetProductSpecificationsAsync(int id)
        {
            return await context.ProductsSpecifications
                .AsNoTracking()
                .Include(p => p.Specification)
                .Where(p => p.ProductId == id)
                .ToListAsync();
        }

        public async Task<List<MotorcycleProduct>> GetCompatiblePartsAsync(int makeId, int modelId, int displacementId, int yearId)
        {
            return await context.MotorcyclesParts
                .AsNoTracking()
                .Include(mp => mp.Motorcycle)
                .Include(mp => mp.Motorcycle.Make)
                .Include(mp => mp.Motorcycle.Model)
                .Include(mp => mp.Motorcycle.Displacement)
                .Include(mp => mp.Motorcycle.Year)
                .Include(mp => mp.Product.Brand)
                .Where(mp => mp.Motorcycle.MakeId == makeId &&
                             mp.Motorcycle.ModelId == modelId &&
                             mp.Motorcycle.DisplacementId == displacementId &&
                             mp.Motorcycle.YearId == yearId)
                .ToListAsync();
        }

        public async Task<List<ProductViewModel>> GetAllProductsAsync()
        {
            return await context.Products
                .AsNoTracking()
                .Select(p => new ProductViewModel()
                {
                    Id = p.Id,
                    Title = p.Title,
                    Type = p.Type.Name,
                    Category = p.Category.ToString(),
                    Brand = p.Brand.Name,
                    Description = p.Description,
                    Price = p.Price,
                    StockQuantity = p.StockQuantity,
                    ImageUrl = p.ImageUrl,
                })
                .ToListAsync();
        }

        public async Task AddProductAsync(ProductFormViewModel model)
        {
            Product product = new()
            {
                BrandId = model.BrandId,
                TypeId = model.TypeId,
                Category = model.Category.Value,
                Title = model.Title,
                Description = model.Description,
                Price = model.Price,
                StockQuantity = model.StockQuantity,
                ImageUrl = model.ImageUrl,
            };

            context.Products.Add(product);
            await context.SaveChangesAsync();
        }

        public async Task<ProductFormViewModel> GetProductEditFormAsync(int id)
        {
            var product = await context.Products
                .AsNoTracking()
                .Include(p => p.Brand)
                .Include(p => p.Type)
                .Include(p => p.Specifications)
                .Include(p => p.MotorcycleParts)
                .FirstOrDefaultAsync(p => p.Id == id);

            var brands = await context.ProductBrands.ToListAsync();
            var types = await context.ProductTypes.ToListAsync();

            if (product == null || brands == null || types == null)
            {
                throw new InvalidOperationException("Product not found");
            }

            ProductFormViewModel productFormViewModel = new()
            {
                Title = product.Title,
                Description = product.Description,
                Price = product.Price,
                ImageUrl = product.ImageUrl,
                StockQuantity = product.StockQuantity,
                Category = product.Category,
                BrandId = product.Brand.Id,
                TypeId = product.Type.Id,
                Specifications = product.Specifications,
                MotorcycleParts = product.MotorcycleParts,
                Brands = brands,
                Types = types
            };

            return productFormViewModel;
        }

        public async Task EditProductAsync(int id, ProductFormViewModel model)
        {
            try
            {
                Product product = await context.Products.FindAsync(id) ?? throw new InvalidOperationException("Product not found");

                product.Title = model.Title;
                product.Description = model.Description;
                product.Price = model.Price;
                product.ImageUrl = model.ImageUrl;
                product.StockQuantity = model.StockQuantity;
                product.BrandId = model.BrandId;
                product.TypeId = model.TypeId;
                product.Specifications = model.Specifications;
                product.Category = (ProductCategory)Enum.Parse(typeof(ProductCategory), model.Category.ToString());

                context.Products.Update(product);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error editing product.", ex);
            }
        }

        public async Task DeleteProductAsync(int id)
        {
            try
            {
                Product product = await context.Products.FindAsync(id) ?? throw new InvalidOperationException("Product not found");

                context.Products.Remove(product);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting product.", ex);
            }
        }

        public async Task<List<ProductBrand>> GetAllProductBrandsAsync()
        {
            return await context.ProductBrands
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<List<ProductType>> GetAllProductTypesAsync()
        {
            return await context.ProductTypes
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<List<Specification>> GetAllSpecificationsAsync()
        {
            return await context.Specifications
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task AddProductBrandAsync(BrandFormViewModel model)
        {
            ProductBrand brand = new()
            {
                Name = model.Name,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
            };

            context.ProductBrands.Add(brand);
            await context.SaveChangesAsync();
        }

        public async Task AddSpecificationAsync(SpecificationFormViewModel model)
        {
            try
            {
                Specification specification = new()
                {
                    Title = model.Title,
                    Value = model.Value
                };

                await context.Specifications.AddAsync(specification);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding specification.", ex);
            }
        }

        public async Task LinkProductMotorcycleAsync(int productId, int motorcycleId)
        {
            MotorcycleProduct productMoto = new()
            {
                ProductId = productId,
                MotorcycleId = motorcycleId
            };

            context.MotorcyclesParts.Add(productMoto);
            await context.SaveChangesAsync();
        }

        public async Task LinkProductSpecificationAsync(int productId, int specificationId)
        {
            ProductSpecification productSpec = new()
            {
                ProductId = productId,
                SpecificationId = specificationId
            };

            context.ProductsSpecifications.Add(productSpec);
            await context.SaveChangesAsync();
        }

        public async Task UpdateStockQuantityAsync(OrderFormViewModel order)
        {
            Cart cart = await context.Carts
                .Where(c => c.Id == order.CartId
                    && c.UserId == order.UserId)
                .OrderByDescending(c => c)
                .FirstOrDefaultAsync();

            List<CartProduct> cartProducts = await context.CartsProducts
                .Where(cp => cp.CartId == cart.Id)
                .ToListAsync();

            foreach (var cp in cartProducts)
            {
                if (cp != null)
                {
                    Product product = await context.Products
                        .Where(p => p.Id == cp.ProductId)
                        .FirstOrDefaultAsync();

                    product.StockQuantity -= cp.Quantity;
                }
            }

            await context.SaveChangesAsync();
        }
    }
}
