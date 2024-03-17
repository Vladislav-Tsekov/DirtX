using DirtX.Infrastructure.Data.Models.Products;

namespace DirtX.Core.Interfaces
{
    public interface IProductService<T>
    {
        Task<List<T>> GetAllProductsAsync();
        Task<T> GetDetailsAsync(int id);
        Task<List<ProductBrand>> GetDistinctBrandsAsync();
    }
}
