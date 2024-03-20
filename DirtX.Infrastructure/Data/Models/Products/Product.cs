using DirtX.Infrastructure.Data.Models.Orders;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static DirtX.Infrastructure.Shared.ValidationConstants;

namespace DirtX.Infrastructure.Data.Models.Products
{
    public abstract class Product
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(BrandId))]
        public ProductBrand Brand { get; set; }
        public int BrandId { get; set; }

        [Required]
        [MaxLength(ProductTitleMaxLength)]
        public string Title { get; set; }

        [Required]
        [Column(TypeName = "decimal(9, 2)")]
        [Range(typeof(decimal), ProductMinPrice, ProductMaxPrice, ConvertValueInInvariantCulture = true)]
        //TODO - TROUBLESHOOT THE CONVERT IN THIS SCENARIO
        public decimal Price { get; set; }

        //TODO - PROPERTY bool IsOnSale? / SalePercentage

        [Required]
        [MaxLength(ProductDescriptionMaxLength)]
        public string Description { get; set; }

        [Required]
        public bool IsAvailable { get; set; }

        [Required]
        public int StockQuantity { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        public ICollection<Specification> Specifications { get; set; }
        public ICollection<CartProduct> CartProducts { get; set; }
        public ICollection<Wishlist> Wishlists { get; set; }
    }
}
