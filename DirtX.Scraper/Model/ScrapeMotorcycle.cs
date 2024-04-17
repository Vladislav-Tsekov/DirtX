namespace DirtX.Scraper.Models
{
    public class ScrapeMotorcycle
    {
        public ScrapeMotorcycle(string make, int displacement, int year, decimal price, string link)
        {
            Make = make;
            Displacement = displacement;
            Year = year;
            Price = price;
            Link = link;
        }

        public string Make { get; }
        public int Displacement { get; }
        public int Year { get; }
        public decimal Price { get; }
        public string Link { get; }
    }
}
