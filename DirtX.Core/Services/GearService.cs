using DirtX.Core.Interfaces;
using DirtX.Infrastructure.Data.Models.Products;
using Microsoft.EntityFrameworkCore;

namespace DirtX.Core.Services
{
    public class GearService : IProductService<Gear>
    {
        private readonly DbContext _context;

        public Task<List<Gear>> GetAllProductsAsync()
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

        public Task<Gear> GetProductDetailsAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Gear>> GetProductsByBrandAsync(ProductBrand brand)
        {
            throw new NotImplementedException();
        }
    }
}
