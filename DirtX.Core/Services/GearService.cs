using DirtX.Core.Interfaces;
using DirtX.Infrastructure.Data.Models.Enums;
using DirtX.Infrastructure.Data.Models.Mappings;
using DirtX.Infrastructure.Data.Models.Products;
using DirtX.Web.Data;
using Microsoft.EntityFrameworkCore;

namespace DirtX.Core.Services
{
    public class GearService : IProductService<Gear, GearType>
    {
        private readonly ApplicationDbContext context;

        public GearService(ApplicationDbContext _context)
        {
            context = _context;
        }

        public async Task<Gear> GetProductAsync(int id)
        {
            Gear gear = await context.Gears
                .AsNoTracking()
                .Include(p => p.Brand)
                .Where(p => p.Id == id)
                .FirstOrDefaultAsync();

            return gear;
        }

        public async Task<List<Gear>> GetAllProductsAsync() => await context.Gears.AsNoTracking().ToListAsync();

        public async Task<ProductBrand> GetProductBrandAsync(string brandName) => await context.ProductBrands.AsNoTracking().FirstOrDefaultAsync(b => b.Name == brandName);

        public async Task<List<Gear>> GetProductsByBrandAsync(ProductBrand brand) => await context.Gears.Where(p => p.BrandId == brand.Id).AsNoTracking().ToListAsync();

        public async Task<List<Gear>> GetAllProductsByTypeAsync(GearType type) => await context.Gears.Where(p => p.GearType == type).AsNoTracking().ToListAsync();

        public async Task<List<ProductBrand>> GetDistinctProductBrandsAsync()
        {
            List<int> distinctBrands = await context.Gears
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
