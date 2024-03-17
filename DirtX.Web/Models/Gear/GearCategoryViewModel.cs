namespace DirtX.Web.Models.Gear;
using DirtX.Infrastructure.Data.Models.Products;

public class GearCategoryViewModel
{
    public string CategoryName { get; set; }
    public List<Gear> Gears { get; set; }
}
