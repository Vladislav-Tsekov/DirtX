namespace DirtX.Web.Models.Gear;
using DirtX.Infrastructure.Data.Models.Products;

public class GearBrandViewModel
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
    public List<Gear> Gears { get; set; }
}
