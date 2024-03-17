using DirtX.Core.Interfaces;
using DirtX.Infrastructure.Data.Models.Products;
using Microsoft.EntityFrameworkCore;

namespace DirtX.Core.Services
{
    public class GearService : IProductService<Gear>
    {
        private readonly DbContext _context;

        public GearService(DbContext context)
        {
            _context = context;
        }

        public Task<List<Gear>> GetAllByCategoryAsync(Enum category)
        {
            throw new NotImplementedException();
        }

        public Task<List<Gear>> GetAllProductsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<Gear>> GetByBrandAsync(string brandName)
        {
            throw new NotImplementedException();
        }

        public Task<List<Gear>> GetByCategoryAsync(Enum category)
        {
            throw new NotImplementedException();
        }

        public Task<Gear> GetDetailsAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductBrand>> GetDistinctBrandsAsync()
        {
            throw new NotImplementedException();
        }
    }

}
