namespace DirtX.Infrastructure.Data.Models.Trailers
{
    public class Trailer
    {
        public int TrailerId { get; set; }
        public string TrailerType { get; set; }
        public decimal CostPerDay { get; set; }
        public int Capacity { get; set; }
        public decimal MaximumLoad { get; set; }
        public bool IsAvailable { get; set; }
    }
}
