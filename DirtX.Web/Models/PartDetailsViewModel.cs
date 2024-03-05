using DirtX.Infrastructure.Data.Models.Enums;

namespace DirtX.Models
{
    public class PartDetailsViewModel
    {
        public int Id { get; set; }
        public PartType Type { get; set; }
        public string BrandName { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public bool IsAvailable { get; set; }
        public int StockQuantity { get; set; }
    }
}
