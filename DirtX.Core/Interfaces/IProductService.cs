using DirtX.Infrastructure.Data.Models.Mappings;
using DirtX.Infrastructure.Data.Models.Products;

namespace DirtX.Core.Interfaces
{
    public interface IProductService<T, TEnum> where TEnum : Enum
    {
        Task<T> GetProductAsync(int id);
        Task<List<T>> GetAllProductsAsync();
        Task<List<T>> GetAllProductsByTypeAsync(TEnum type);
        Task<List<ProductSpecification>> GetProductSpecificationsAsync(int id);
        Task<ProductBrand> GetProductBrandAsync(string brandName);
        Task<List<T>> GetProductsByBrandAsync(ProductBrand brand);
        Task<List<ProductBrand>> GetDistinctProductBrandsAsync();
    }
}
