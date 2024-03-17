using DirtX.Infrastructure.Data.Models.Products;

namespace DirtX.Web.Models.Part
{
    public class PartIndexViewModel
    {
        public string CategoryName { get; set; }
        public string ImageUrl { get; set; }
        public List<ProductBrand> Brands { get; set; }
    }
}
