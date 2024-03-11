using DirtX.Infrastructure.Data.Models.ProductModels;

namespace DirtX.Models
{
    public class CompatiblePartsViewModel
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public string Displacement { get; set; }
        public string Year { get; set; }
        public IEnumerable<Part> Parts { get; set; }
    }
}
