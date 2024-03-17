using DirtX.Core.Interfaces;
using DirtX.Infrastructure.Data.Models.Products;
using Microsoft.EntityFrameworkCore;

namespace DirtX.Core.Services
{
    public class OilService : IProductService<Oil>
    {
        private readonly DbContext _context;

        public OilService(DbContext context)
        {
            _context = context;
        }

        public Task<List<Oil>> GetAllByCategoryAsync(Enum category)
        {
            throw new NotImplementedException();
        }

        public Task<List<Oil>> GetAllProductsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<Oil>> GetByBrandAsync(string brandName)
        {
            throw new NotImplementedException();
        }

        public Task<List<Oil>> GetByCategoryAsync(Enum category)
        {
            throw new NotImplementedException();
        }

        public Task<Oil> GetDetailsAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductBrand>> GetDistinctBrandsAsync()
        {
            throw new NotImplementedException();
        }
    }
}
