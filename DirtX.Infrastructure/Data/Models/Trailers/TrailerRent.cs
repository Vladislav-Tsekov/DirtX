using DirtX.Infrastructure.Data.Models.Users;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static DirtX.Infrastructure.Shared.ValidationConstants;

namespace DirtX.Infrastructure.Data.Models.Trailers
{
    public class TrailerRent
    {
        [Key]
        public int RentId { get; set; }

        [ForeignKey(nameof(TrailerId))]
        public Trailer Trailer { get; set; }
        public int TrailerId { get; set; }

        [ForeignKey(nameof(UserId))]
        public string UserId { get; set; }
        public AppUser User { get; set; }

        [Required]
        public int Duration { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        public DateTime ReturnDate { get; set; }

        [Required]
        [Column(TypeName = "decimal(10, 2)")]
        [Range(typeof(decimal), TrailerRentMinTotalCost, TrailerRentMaxTotalCost, ConvertValueInInvariantCulture = true)]
        public decimal TotalCost { get; set; }
    }
}
