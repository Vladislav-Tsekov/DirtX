using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using DirtX.Infrastructure.Data.Models.Enums;

namespace DirtX.Infrastructure.Data.Models
{
    public class Part
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey(nameof(BrandId))]
        public Brand Brand { get; set; }
        public int BrandId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Price { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public PartType Type { get; set; }

        [Required]
        public bool IsAvailable { get; set; }

        [Required]
        public int StockQuantity { get; set; }

        public List<Property> Properties { get; set; }
        public List<Fitment> Fitments { get; set; }
    }
}
