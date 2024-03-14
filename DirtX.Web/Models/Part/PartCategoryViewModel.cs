namespace DirtX.Web.Models.Part;
using DirtX.Infrastructure.Data.Models.ProductModels;

public class PartCategoryViewModel
{
    public string CategoryName { get; set; }
    public List<Part> Parts { get; set; }
}
