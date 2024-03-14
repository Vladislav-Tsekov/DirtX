namespace DirtX.Web.Models.Gear;
using DirtX.Infrastructure.Data.Models.ProductModels;

public class GearIndexViewModel
{
    public string CategoryName { get; set; }
    public string ImageUrl { get; set; }
    public List<ProductBrand> Brands { get; set; }
}
