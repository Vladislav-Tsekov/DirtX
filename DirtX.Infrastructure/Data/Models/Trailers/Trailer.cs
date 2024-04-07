using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static DirtX.Infrastructure.Shared.ValidationConstants;

namespace DirtX.Infrastructure.Data.Models.Trailers
{
    public class Trailer
    {
        [Key]
        [Comment("Identifier for the trailer.")]
        public int Id { get; set; }

        [Required]
        [Comment("Title or name of the trailer.")]
        public string Title { get; set; }

        [Required]
        [Column(TypeName = "decimal(5, 2)")]
        [Range(typeof(decimal), TrailerMinCostPerDay, TrailerMaxCostPerDay, ConvertValueInInvariantCulture = true)]
        [Comment("Cost per day for renting the trailer.")]
        public decimal CostPerDay { get; set; }

        [Required]
        [Range(TrailerMinCapacity, TrailerMaxCapacity)]
        [Comment("Capacity of the trailer (max number of motorcycles).")]
        public int Capacity { get; set; }

        [Required]
        [Range(TrailerMinLoad, TrailerMaxLoad)]
        [Comment("Maximum load capacity of the trailer (in kilograms).")]
        public int MaximumLoad { get; set; }

        [Required]
        [Comment("Indicates whether the trailer is available for renting.")]
        public bool IsAvailable { get; set; }

        [Required]
        [Comment("URL pointing to the image of the trailer.")]
        public string ImageUrl { get; set; }
    }

}
