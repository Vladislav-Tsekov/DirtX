using DirtX.Core.Interfaces;
using DirtX.Infrastructure.Data.Models.Enums;
using DirtX.Infrastructure.Data.Models.Products;
using DirtX.Web.Data;
using Microsoft.EntityFrameworkCore;
using DirtX.Infrastructure.Data.Models.Mappings;

namespace DirtX.Core.Services
{
    public class OilService : IProductService<Oil, OilType>
    {
        private readonly ApplicationDbContext context;

        public OilService(ApplicationDbContext _context)
        {
            context = _context;
        }

        public async Task<Oil> GetProductAsync(int id)
        {
            Oil oil = await context.Oils
                .AsNoTracking()
                .Include(p => p.Brand)
                .Where(p => p.Id == id)
                .FirstOrDefaultAsync();

            return oil;
        }

        public async Task<List<Oil>> GetAllProductsAsync() => await context.Oils.AsNoTracking().ToListAsync();

        public async Task<ProductBrand> GetProductBrandAsync(string brandName) => await context.ProductBrands.AsNoTracking().FirstOrDefaultAsync(b => b.Name == brandName);

        public async Task<List<Oil>> GetProductsByBrandAsync(ProductBrand brand) => await context.Oils.Where(p => p.BrandId == brand.Id).AsNoTracking().ToListAsync();

        public async Task<List<Oil>> GetAllProductsByTypeAsync(OilType type) => await context.Oils.Where(p => p.OilType == type).AsNoTracking().ToListAsync();

        public async Task<List<ProductBrand>> GetDistinctProductBrandsAsync()
        {
            List<int> distinctBrands = await context.Oils
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
