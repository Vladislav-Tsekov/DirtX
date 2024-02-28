using DirtX.Infrastructure.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DirtX.Infrastructure.Data.Models
{
    public class Part : Product
    {
        [Required]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Price { get; set; }

        [Required]
        public PartType Type { get; set; }

        public List<Property> Properties { get; set; }
        public List<Fitment> Fitments { get; set; }
    }
}
