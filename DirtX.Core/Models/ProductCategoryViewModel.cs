using DirtX.Infrastructure.Data.Models.Products;

namespace DirtX.Core.Models
{
    public class ProductCategoryViewModel<T>
    {
        public string CategoryName { get; set; }
        public List<T> Products { get; set; }
    }
}
