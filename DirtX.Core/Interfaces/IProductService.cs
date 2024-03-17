using DirtX.Infrastructure.Data.Models.Products;

namespace DirtX.Core.Interfaces
{
    public interface IProductService<T>
    {
        Task<List<T>> GetAllProductsAsync();
        Task<T> GetProductDetailsAsync(int id);
        Task<ProductBrand> GetProductBrandAsync(string brandName);
        Task<List<T>> GetProductsByBrandAsync(ProductBrand brand);
        Task<List<ProductBrand>> GetDistinctProductBrandsAsync();
    }
}
