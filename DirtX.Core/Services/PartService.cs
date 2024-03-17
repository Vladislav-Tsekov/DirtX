using DirtX.Core.Interfaces;
using DirtX.Infrastructure.Data.Models.Products;
using DirtX.Web.Data;
using Microsoft.EntityFrameworkCore;

namespace DirtX.Core.Services
{
    public class PartService : IProductService<Part>
    {
        private readonly ApplicationDbContext context;

        public PartService(ApplicationDbContext _context)
        {
            context = _context;
        }

        public async Task<List<Part>> GetAllProductsAsync()
        {
            List<Part> parts = await context.Parts.ToListAsync();

            return parts;
        }

        public async Task<ProductBrand> GetProductBrandAsync(string brandName) => await context.ProductBrands.FirstOrDefaultAsync(b => b.Name == brandName);

        public async Task<List<Part>> GetProductsByBrandAsync(ProductBrand brand) => await context.Parts.Where(p => p.BrandId == brand.Id).ToListAsync();

        public async Task<List<ProductBrand>> GetDistinctProductBrandsAsync()
        {
            var distinctBrands = await context.Parts
                .Select(p => p.BrandId)
                .Distinct()
                .ToListAsync();

            var brands = await context.ProductBrands
                .Where(brand => distinctBrands.Contains(brand.Id))
                .ToListAsync();

            return brands;
        }
       
        public async Task<Part> GetProductDetailsAsync(int id)
        {
            var part = await context.Parts
                .Include(p => p.Brand)
                .Include(p => p.PartProperties)
                .ThenInclude(pp => pp.Specification)
                .ThenInclude(pp => pp.Title)
                .FirstOrDefaultAsync(p => p.Id == id);

            return part;
        }
    }
}
