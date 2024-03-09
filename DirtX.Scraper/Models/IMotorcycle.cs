namespace DirtX.Scraper.Models
{
    public interface IMotorcycle
    {
        string Make { get; }
        int Displacement { get; }
        int Year { get; }
        decimal Price { get; }
        string Link { get; }
    }
}
