namespace DirtX.Web.Models.Part;
using DirtX.Infrastructure.Data.Models.Products;

public class OilCategoryViewModel
{
    public string CategoryName { get; set; }
    public List<Oil> Oils { get; set; }
}
