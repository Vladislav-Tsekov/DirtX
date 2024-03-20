using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static DirtX.Infrastructure.Shared.ValidationConstants;

namespace DirtX.Infrastructure.Data.Models.Trailers
{
    public class Trailer
    {
        [Key]
        public int TrailerId { get; set; }

        [Required]
        [MaxLength(TrailerTypeMaxLength)]
        public string TrailerType { get; set; }

        [Required]
        [Column(TypeName = "decimal(5, 2)")]
        [Range(typeof(decimal), TrailerMinCostPerDay, TrailerMaxCostPerDay, ConvertValueInInvariantCulture = true)]
        public decimal CostPerDay { get; set; }

        [Required]
        [Range(TrailerMinCapacity, TrailerMaxCapacity)]
        public int Capacity { get; set; }

        [Required]
        [Range(TrailerMinLoad, TrailerMaxLoad)]
        public int MaximumLoad { get; set; }

        [Required]
        public bool IsAvailable { get; set; }
    }
}
