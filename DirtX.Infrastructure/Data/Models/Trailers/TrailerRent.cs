using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DirtX.Infrastructure.Data.Models.Trailers
{
    public class TrailerRent
    {
        [Key]
        public int RentalId { get; set; }

        [ForeignKey(nameof(TrailerId))]
        public Trailer Trailer { get; set; }
        public int TrailerId { get; set; }

        //TODO - FOREIGN KEY TO USER
        //public string UserId { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime ReturnDate { get; set; }

        [Required]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal TotalCost { get; set; }
    }
}
