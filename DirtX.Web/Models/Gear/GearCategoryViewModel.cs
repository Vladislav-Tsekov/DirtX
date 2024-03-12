namespace DirtX.Models.Gear;
using DirtX.Infrastructure.Data.Models.ProductModels;

public class GearCategoryViewModel
{
    public string CategoryName { get; set; }
    public List<Gear> Gears { get; set; }
}
