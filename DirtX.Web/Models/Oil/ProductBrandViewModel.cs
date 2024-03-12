namespace DirtX.Models.Part;
using DirtX.Infrastructure.Data.Models.ProductModels;

public class OilBrandViewModel
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
    public List<Oil> Oils { get; set; }
}