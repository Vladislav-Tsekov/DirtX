using DirtX.Infrastructure.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DirtX.Infrastructure.Data.Models
{
    public class RidingGear
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
        public RidingGearSize Size { get; set; }

        [Required]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Price { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public RidingGearType Type { get; set; }

        [Required]
        public bool IsAvailable { get; set; }

        [Required]
        public int StockQuantity { get; set; }

        //TODO - EVALUATE THE NEED TO IMPLEMENT PROPERTY FOR PIECES OF RIDING GEAR, FOLLOWING THE PARTS MODEL
    }
}
