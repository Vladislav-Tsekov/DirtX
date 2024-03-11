using DirtX.Infrastructure.Data.Models.ProductModels;

namespace DirtX.Models
{
    public class ProductCategoryViewModel
    {
        public string CategoryName { get; set; }
        public List<Part> Parts { get; set; }
        public List<Oil> Oils { get; set; }
        public List<Gear> Gears { get; set; }
    }
}
