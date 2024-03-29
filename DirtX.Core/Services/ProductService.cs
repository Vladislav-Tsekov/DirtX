using DirtX.Core.Interfaces;
using DirtX.Infrastructure.Data;
using DirtX.Infrastructure.Data.Models;
using DirtX.Infrastructure.Data.Models.Enums;
using DirtX.Infrastructure.Data.Models.Mappings;
using DirtX.Infrastructure.Data.Models.Products;
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
                .Where(p => p.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Product>> GetAllPartsAsync()
        {
            return await context.Products
                .Where(p => p.Type.Name == "Part")
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<List<Product>> GetAllOilsAsync()
        {
            return await context.Products
                .Where(p => p.Type.Name == "Oil")
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<List<Product>> GetAllGearsAsync()
        {
            return await context.Products
                .Where(p => p.Type.Name == "Gear")
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

        public async Task<List<Product>> GetAllProductsByCategoryAsync(ProductCategory category)
        {
            return await context.Products
                .Where(p => p.Category == category)
                .AsNoTracking()
                .ToListAsync();
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
                .ThenInclude(pp => pp.Title)
                .Where(p => p.ProductId == id)
                .ToListAsync();
        }

        public async Task<List<MotorcycleProduct>> GetCompatiblePartsAsync(int makeId, int modelId, int displacementId, int yearId)
        {
            return await context.MotorcyclesParts
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
    }
}
