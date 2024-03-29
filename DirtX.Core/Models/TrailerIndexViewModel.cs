namespace DirtX.Core.Models
{
    public class TrailerIndexViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal CostPerDay { get; set; }
        public int Capacity { get; set; }
        public int MaximumLoad { get; set; }
        public bool IsAvailable { get; set; }
        public string ImageUrl { get; set; }
    }
}
