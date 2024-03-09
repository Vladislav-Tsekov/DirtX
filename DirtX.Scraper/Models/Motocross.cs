namespace DirtX.Scraper.Models
{
    public class Motocross : Motorcycle
    {
        public Motocross(string make, int cc, int year, decimal price, string link)
        {
            Make = make;
            CC = cc;
            Year = year;
            Price = price;
            Link = link;
        }
    }
}
