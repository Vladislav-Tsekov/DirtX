using DirtX.Infrastructure.Data.Models.ProductModels;

namespace DirtX.Models
{
    public class PartIndexViewModel
    {
        public string CategoryName { get; set; }
        public string ImageUrl { get; set; }
        public List<ProductBrand> Brands { get; set; }
    }
}
