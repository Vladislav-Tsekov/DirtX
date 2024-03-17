using DirtX.Core.Interfaces;
using DirtX.Infrastructure.Data.Models.Enums;
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

        public async Task<List<ProductBrand>> GetDistinctBrandsAsync()
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

        public async Task<List<Part>> GetAllByCategoryAsync(Enum category)
        {
            PartType partCategory = (PartType)category;

            List<Part> parts = await context.Parts.Where(p => p.Type == partCategory).ToListAsync();

            return parts;
        }

        public async Task<List<Part>> GetByCategoryAsync(Enum category)
        {
            PartType partCategory = (PartType)category;

            List<Part> parts = await context.Parts.Where(p => p.Type == partCategory).ToListAsync();

            return parts;
        }

        public async Task<Part> GetDetailsAsync(int id)
        {
            var part = await context.Parts
                .Include(p => p.Brand)
                .Include(p => p.PartProperties)
                .ThenInclude(pp => pp.Specification)
                .FirstOrDefaultAsync(p => p.Id == id);

            //TODO - BETTER NULL HANDLING
            if (part == null)
            {
                return null;
            }

            return part;
        }
    }
}
