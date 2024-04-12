namespace DirtX.Core.Models.Admin
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        //public ProductBrand Brand { get; set; }
        public string Brand { get; set; }

        //public ProductType Type { get; set; }

        public string Type { get; set; }
        //public ProductCategory Category { get; set; }

        public string Category { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int StockQuantity { get; set; }
        public string ImageUrl { get; set; }
    }
}
