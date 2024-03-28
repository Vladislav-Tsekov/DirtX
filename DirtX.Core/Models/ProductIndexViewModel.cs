using DirtX.Infrastructure.Data.Models.Products;

namespace DirtX.Core.Models
{
    public class ProductIndexViewModel
    {
        public string ProductType { get; set; }
        public List<ProductBrand> Brands { get; set; }
    }
}
