using DirtX.Infrastructure.Data.Models.ProductModels;

namespace DirtX.Models
{
    public class PartCategoryViewModel
    {
        public string CategoryName { get; set; }
        public List<Part> Parts { get; set; }
    }
}
