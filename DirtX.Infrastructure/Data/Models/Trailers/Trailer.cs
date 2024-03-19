using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DirtX.Infrastructure.Data.Models.Trailers
{
    public class Trailer
    {
        [Key]
        public int TrailerId { get; set; }

        [Required]
        public string TrailerType { get; set; }

        [Required]
        [Column(TypeName = "decimal(5, 2)")]
        public decimal CostPerDay { get; set; }

        [Required]
        public int Capacity { get; set; }

        public int MaximumLoad { get; set; }

        [Required]
        public bool IsAvailable { get; set; }
    }
}
