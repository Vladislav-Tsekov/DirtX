namespace DirtX.Core.Interfaces
{
    public interface IProductService<T>
    {
        Task<List<T>> GetByBrandAsync(string brandName);
        Task<List<T>> GetAllByCategoryAsync(Enum category);
        Task<List<T>> GetByCategoryAsync(Enum category);
        Task<T> GetDetailsAsync(int id);
    }
}
