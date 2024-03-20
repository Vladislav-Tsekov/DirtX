using DirtX.Infrastructure.Data.Models;
using DirtX.Infrastructure.Data.Models.Products;

namespace DirtX.Core.Interfaces
{
    public interface IProductService<T>
    {
        Task<T> GetProductAsync(int id);
        Task<List<T>> GetAllProductsAsync();
        Task<List<ProductSpecification>> GetProductSpecificationsAsync(int id);
        Task<ProductBrand> GetProductBrandAsync(string brandName);
        Task<List<T>> GetProductsByBrandAsync(ProductBrand brand);
        Task<List<ProductBrand>> GetDistinctProductBrandsAsync();
    }
}
