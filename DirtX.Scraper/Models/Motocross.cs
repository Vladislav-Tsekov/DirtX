namespace DirtX.Scraper.Models
{
    public class Motocross : IMotorcycle
    {
        public Motocross(string make, int cc, int year, decimal price, string link)
        {
            Make = make;
            Displacement = cc;
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
