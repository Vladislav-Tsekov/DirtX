using DirtX.Core.Enums;
using DirtX.Core.Models.Admin;
using DirtX.Infrastructure.Data.Models;
using DirtX.Infrastructure.Data.Models.Enums;
using DirtX.Infrastructure.Data.Models.Mappings;
using DirtX.Infrastructure.Data.Models.Products;

namespace DirtX.Core.Interfaces
{
    public interface IProductService
    {
        Task<Product> AddProductAsync(ProductFormViewModel model);
        Task<List<Product>> GetAllProductsAsync();
        Task<List<Product>> QueryAllProductsAsync(ProductsQueryModel model, ProductSorting sorting);



        Task<Product> GetProductAsync(int id);
        Task<List<Product>> GetAllPartsAsync();
        Task<List<Product>> GetAllOilsAsync();
        Task<List<Product>> GetAllGearsAsync();
        Task<List<ProductBrand>> GetDistinctProductBrandsAsync(List<Product> products);
        List<ProductCategory> GetProductCategories(List<Product> products);
        Task<List<Product>> GetAllProductsByCategoryAsync(ProductCategory category, ProductSorting sorting);
        Task<List<ProductSpecification>> GetProductSpecificationsAsync(int id);
        Task<ProductBrand> GetProductBrandAsync(string brandName);
        Task<List<Product>> GetProductsByBrandAsync(ProductBrand brand);
        Task<List<MotorcycleProduct>> GetCompatiblePartsAsync(int makeId, int modelId, int displacementId, int yearId);
    }
}
