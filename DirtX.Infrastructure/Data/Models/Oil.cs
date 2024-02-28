using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using DirtX.Infrastructure.Data.Models.Enums;

namespace DirtX.Infrastructure.Data.Models
{
    public class Oil
    {
        public int Id { get; set; }

        [Required]
        public string Brand { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Price { get; set; }

        [Required]
        public bool IsAvailable { get; set; }

        [Required]
        public int StockQuantity { get; set; }

        [Required]
        public string PackageSize { get; set; }

        public OilType Type { get; set; }
    }
}
