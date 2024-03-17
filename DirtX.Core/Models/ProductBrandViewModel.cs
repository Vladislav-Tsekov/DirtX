namespace DirtX.Core.Models
{
    public class ProductBrandViewModel<T>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public List<T> Products { get; set; }
    }
}
