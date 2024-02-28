using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DirtX.Infrastructure.Data.Models
{
    public class Fitment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Model { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public int Cc { get; set; }

        [ForeignKey(nameof(PartId))]
        public Part Part { get; set; }
        public int PartId { get; set; }
    }
}
