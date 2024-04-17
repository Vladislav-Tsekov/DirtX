using DirtX.Core.Enums;
using DirtX.Core.Models;
using DirtX.Core.Models.Admin;
using DirtX.Infrastructure.Data.Models;
using DirtX.Infrastructure.Data.Models.Enums;
using DirtX.Infrastructure.Data.Models.Mappings;
using DirtX.Infrastructure.Data.Models.Products;

namespace DirtX.Core.Interfaces
{
    public interface IProductService
    {
        Task AddProductAsync(ProductFormViewModel model);
        Task<List<ProductViewModel>> GetAllProductsAsync();
        Task<ProductFormViewModel> GetProductEditFormAsync(int id);
        Task EditProductAsync(int id, ProductFormViewModel model);
        Task DeleteProductAsync(int id);
        Task<List<ProductBrand>> GetAllProductBrandsAsync();
        Task<List<ProductType>> GetAllProductTypesAsync();
        Task<List<Specification>> GetAllSpecificationsAsync();
        Task AddProductBrandAsync(BrandFormViewModel model);
        Task AddSpecificationAsync(SpecificationFormViewModel model);
        Task LinkProductMotorcycleAsync(int productId, int motorcycleId);
        Task LinkProductSpecificationAsync(int productId, int specificationId);
        Task UpdateStockQuantityAsync(OrderFormViewModel order);
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
