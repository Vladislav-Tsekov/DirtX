using DirtX.Infrastructure.Data.Models.ProductModels;

namespace DirtX.Models
{
    public class ProductBrandViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public List<Part> Parts { get; set; }
        public List<Oil> Oils { get; set; }
        public List<Gear> Gears { get; set; }
    }
}
