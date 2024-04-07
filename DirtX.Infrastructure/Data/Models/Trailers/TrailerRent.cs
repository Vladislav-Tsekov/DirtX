using DirtX.Infrastructure.Data.Models.Users;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static DirtX.Infrastructure.Shared.ValidationConstants;

namespace DirtX.Infrastructure.Data.Models.Trailers
{
    public class TrailerRent
    {
        [Key]
        [Comment("Identifier for the trailer rent.")]
        public int RentId { get; set; }

        [ForeignKey(nameof(TrailerId))]
        [Comment("The rented trailer.")]
        public Trailer Trailer { get; set; }
        public int TrailerId { get; set; }

        [ForeignKey(nameof(UserId))]
        [Comment("The user who rented the trailer.")]
        public string UserId { get; set; }
        public AppUser User { get; set; }

        [Required]
        [Comment("Duration of the trailer rental (in days).")]
        public int Duration { get; set; }

        [Required]
        [Comment("Start date of the trailer rental.")]
        public DateTime StartDate { get; set; }

        [Required]
        [Comment("Return date of the trailer rental.")]
        public DateTime ReturnDate { get; set; }

        [Required]
        [Column(TypeName = "decimal(10, 2)")]
        [Range(typeof(decimal), TrailerRentMinTotalCost, TrailerRentMaxTotalCost, ConvertValueInInvariantCulture = true)]
        [Comment("Total cost of the trailer rental.")]
        public decimal TotalCost { get; set; }
    }

}
