using DirtX.Scraper.Data.Models.Enums;

namespace DirtX.Scraper.Models
{
    public class Motorcycle
    {
        public Motorcycle(string make, int displacement, int year, decimal price, string link, Category ctg)
        {
            Make = make;
            Displacement = displacement;
            Year = year;
            Price = price;
            Link = link;
            Category = ctg;
        }

        public string Make { get; }
        public int Displacement { get; }
        public int Year { get; }
        public decimal Price { get; }
        public string Link { get; }
        public Category Category { get; }
    }
}
