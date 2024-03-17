using DirtX.Core.Interfaces;
using DirtX.Infrastructure.Data.Models.Products;
using Microsoft.EntityFrameworkCore;

namespace DirtX.Core.Services
{
    public class OilService : IProductService<Oil>
    {
        private readonly DbContext _context;

        public Task<List<Oil>> GetAllProductsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductBrand>> GetDistinctProductBrandsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ProductBrand> GetProductBrandAsync(string brandName)
        {
            throw new NotImplementedException();
        }

        public Task<Oil> GetProductDetailsAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Oil>> GetProductsByBrandAsync(ProductBrand brand)
        {
            throw new NotImplementedException();
        }
    }
}
