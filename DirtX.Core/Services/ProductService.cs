using DirtX.Core.Interfaces;
using DirtX.Infrastructure.Data.Models.Mappings;
using DirtX.Infrastructure.Data.Models.Products;
using DirtX.Web.Data;
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
            Product part = await context.Products
                .AsNoTracking()
                .Include(p => p.Brand)
                .Where(p => p.Id == id)
                .FirstOrDefaultAsync();

            return part;
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            return await context.Products
                .AsNoTracking()
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
                .Where(p => p.BrandId == brand.Id)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<List<Product>> GetAllProductsByCategoryAsync(string category)
        {
            return await context.Products
                .Where(p => p.Category.ToString() == category)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<List<ProductBrand>> GetDistinctProductBrandsAsync()
        {
            List<int> distinctBrands = await context.Products
                .AsNoTracking()
                .Select(p => p.BrandId)
                .Distinct()
                .ToListAsync();

            List<ProductBrand> brands = await context.ProductBrands
                .AsNoTracking()
                .Where(brand => distinctBrands.Contains(brand.Id))
                .ToListAsync();

            return brands;
        }
       
        public async Task<List<ProductSpecification>> GetProductSpecificationsAsync(int id)
        {
            List<ProductSpecification> specs = await context.ProductsSpecifications
                .AsNoTracking()
                .Include(p => p.Specification)
                .ThenInclude(pp => pp.Title)
                .Where(p => p.ProductId == id)
                .ToListAsync();

            return specs;
        }
    }
}
