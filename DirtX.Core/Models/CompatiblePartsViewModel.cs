namespace DirtX.Core.Models;
using DirtX.Infrastructure.Data.Models.Products;

public class CompatiblePartsViewModel
{
    public string Make { get; set; }
    public string Model { get; set; }
    public string Displacement { get; set; }
    public string Year { get; set; }
    public IEnumerable<Product> Parts { get; set; }
}
