namespace DirtX.Infrastructure.Data.Models
{
    public class Part
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }
        public int StockQuantity { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
