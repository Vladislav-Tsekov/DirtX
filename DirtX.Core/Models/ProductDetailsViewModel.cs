using DirtX.Infrastructure.Data.Models.Mappings;

namespace DirtX.Core.Models
{
    public class ProductDetailsViewModel
    {
        public int Id { get; set; }
        public string BrandName { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public int StockQuantity { get; set; }
        public ICollection<ProductSpecification> Specs { get; set; }
    }
}
