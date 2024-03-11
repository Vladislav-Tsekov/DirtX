namespace DirtX.Models.Part;
using DirtX.Infrastructure.Data.Models.ProductModels;


public class PartIndexViewModel
{
    public string CategoryName { get; set; }
    public string ImageUrl { get; set; }
    public List<ProductBrand> Brands { get; set; }
}
