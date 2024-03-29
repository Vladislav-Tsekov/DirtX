using DirtX.Infrastructure.Data.Models.Products;

namespace DirtX.Core.Models
{
    public class ProductBrandViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public List<Product> Products { get; set; }
    }
}
