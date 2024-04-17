using DirtX.Infrastructure.Data.Models.Products;

namespace DirtX.Core.Models
{
    public class ProductIndexViewModel
    {
        public string ProductCategory { get; set; }
        public List<ProductBrand> Brands { get; set; } = new List<ProductBrand>();
    }
}
