namespace DirtX.Scraper.Models
{
    public abstract class Motorcycle
    {
        public string Make { get; set; }
        public int CC { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
        public string Link { get; set; }
    }
}
