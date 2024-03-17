using DirtX.Infrastructure.Data.Models.Products;

namespace DirtX.Core.Interfaces
{
    public interface IProductService<T>
    {
        Task<List<T>> GetAllProductsAsync();
        Task<List<T>> GetAllByCategoryAsync(Enum category);
        Task<List<T>> GetByCategoryAsync(Enum category);
        Task<T> GetDetailsAsync(int id);
        Task<List<ProductBrand>> GetDistinctBrandsAsync();
    }
}
