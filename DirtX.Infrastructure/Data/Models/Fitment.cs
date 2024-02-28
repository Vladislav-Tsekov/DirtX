namespace DirtX.Infrastructure.Data.Models
{
    public class Fitment
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string YearRange { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }

}
