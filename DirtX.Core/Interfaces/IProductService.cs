using DirtX.Infrastructure.Data.Models.Mappings;
using DirtX.Infrastructure.Data.Models.Products;

namespace DirtX.Core.Interfaces
{
    public interface IProductService
    {
        Task<Product> GetProductAsync(int id);
        Task<List<Product>> GetAllProductsAsync();
        Task<List<Product>> GetAllProductsByCategoryAsync(string category);
        Task<List<ProductSpecification>> GetProductSpecificationsAsync(int id);
        Task<ProductBrand> GetProductBrandAsync(string brandName);
        Task<List<Product>> GetProductsByBrandAsync(ProductBrand brand);
        Task<List<ProductBrand>> GetDistinctProductBrandsAsync();
    }
}
