using DirtX.Core.Interfaces;
using DirtX.Infrastructure.Data.Models;
using DirtX.Infrastructure.Data.Models.Enums;
using DirtX.Infrastructure.Data.Models.Products;
using DirtX.Web.Data;
using Microsoft.EntityFrameworkCore;

namespace DirtX.Core.Services
{
    public class PartService : IProductService<Part, PartType>
    {
        private readonly ApplicationDbContext context;

        public PartService(ApplicationDbContext _context)
        {
            context = _context;
        }

        public async Task<Part> GetProductAsync(int id)
        {
            Part part = await context.Parts
                .AsNoTracking()
                .Include(p => p.Brand)
                .Where(p => p.Id == id)
                .FirstOrDefaultAsync();

            return part;
        }

        public async Task<List<Part>> GetAllProductsAsync() => await context.Parts.AsNoTracking().ToListAsync();

        public async Task<ProductBrand> GetProductBrandAsync(string brandName) => await context.ProductBrands.AsNoTracking().FirstOrDefaultAsync(b => b.Name == brandName);

        public async Task<List<Part>> GetProductsByBrandAsync(ProductBrand brand) => await context.Parts.Where(p => p.BrandId == brand.Id).AsNoTracking().ToListAsync();

        public async Task<List<Part>> GetAllProductsByTypeAsync(PartType type) => await context.Parts.Where(p => p.PartType == type).AsNoTracking().ToListAsync();

        public async Task<List<ProductBrand>> GetDistinctProductBrandsAsync()
        {
            List<int> distinctBrands = await context.Parts
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
