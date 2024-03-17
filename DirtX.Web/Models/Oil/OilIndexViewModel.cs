namespace DirtX.Web.Models;
using DirtX.Infrastructure.Data.Models.Products;

public class OilIndexViewModel
{
    public string CategoryName { get; set; }
    public string ImageUrl { get; set; }
    public List<ProductBrand> Brands { get; set; }
}
