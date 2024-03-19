namespace DirtX.Infrastructure.Data.Models.Trailers
{
    public class TrailerRent
    {
        public int RentalId { get; set; }
        public int TrailerId { get; set; }
        public int UserId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public decimal TotalCost { get; set; }
    }
}
