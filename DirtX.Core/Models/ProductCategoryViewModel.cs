using DirtX.Infrastructure.Data.Models.Products;

namespace DirtX.Core.Models
{
    public class ProductCategoryViewModel
    {
        public string CategoryName { get; set; }
        public List<Product> Products { get; set; }
    }
}
