using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using DirtX.Infrastructure.Data.Models.Enums;

namespace DirtX.Infrastructure.Data.Models
{
    public class Oil
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

        public OilType Type { get; set; }

        [Required]
        public string PackageSize { get; set; }

        [Required]
        public bool IsAvailable { get; set; }

        [Required]
        public int StockQuantity { get; set; }
    }
}
