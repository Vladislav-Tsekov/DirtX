namespace DirtX.Infrastructure.Data.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Part> Parts { get; set; }
        public List<Property> Properties { get; set; }
        public List<Fitment> Fitments { get; set; }
    }
}
