using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DirtX.Infrastructure.Data.Models.ProductModels
{
    public abstract class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey(nameof(BrandId))]
        public ProductBrand Brand { get; set; }
        public int BrandId { get; set; }

        [Required]
        public string Title { get; set; }

        //TODO - DECIMAL RANGE NEEDED OR NOT?
        [Required]
        [Column(TypeName = "decimal(10, 2)")]
        //[Range(typeof(decimal), "", "", ConvertValueInInvariantCulture = true)]
        public decimal Price { get; set; }

        //TODO - PROPERTY bool IsOnSale? / SalePercentage

        [Required]
        public string Description { get; set; }

        [Required]
        public bool IsAvailable { get; set; }

        [Required]
        public int StockQuantity { get; set; }
    }
}
