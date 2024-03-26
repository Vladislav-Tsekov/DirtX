using DirtX.Infrastructure.Data.Models.Enums;
using DirtX.Infrastructure.Data.Models.Mappings;
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

        [ForeignKey(nameof(CategoryId))]
        public ProductCategory Category { get; set; }
        public int CategoryId { get; set; }

        [Required]
        public ProductType Type { get; set; }

        [Required]
        [MaxLength(ProductTitleMaxLength)]
        public string Title { get; set; }

        //TODO - TROUBLESHOOT THE CONVERT IN THIS SCENARIO
        [Required]
        [Column(TypeName = "decimal(9, 2)")]
        [Range(typeof(decimal), ProductMinPrice, ProductMaxPrice, ConvertValueInInvariantCulture = true)]
        public decimal Price { get; set; }

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
        public ICollection<MotorcycleProduct> MotorcycleParts { get; set; }
    }
}
