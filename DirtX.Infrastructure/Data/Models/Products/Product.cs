using DirtX.Infrastructure.Data.Models.Enums;
using DirtX.Infrastructure.Data.Models.Mappings;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static DirtX.Infrastructure.Shared.ValidationConstants;

namespace DirtX.Infrastructure.Data.Models.Products
{
    public class Product
    {
        [Key]
        [Comment("Product identifier.")]
        public int Id { get; set; }

        [ForeignKey(nameof(BrandId))]
        [Comment("Product's brand or manufacturer.")]
        public ProductBrand Brand { get; set; }
        public int BrandId { get; set; }

        [ForeignKey(nameof(TypeId))]
        [Comment("Product's type. Could be Part, Oil or Gear.")]
        public ProductType Type { get; set; }
        public int TypeId { get; set; }

        [Required]
        [Comment("Product's category or subtype.")]
        public ProductCategory Category { get; set; }

        [Required]
        [MaxLength(ProductTitleMaxLength)]
        [Comment("Product's title.")]
        public string Title { get; set; }

        [Required]
        [Column(TypeName = "decimal(9, 2)")]
        [Range(typeof(decimal), ProductMinPrice, ProductMaxPrice, ConvertValueInInvariantCulture = true)]
        [Comment("Product's retail price (before discount).")]
        public decimal Price { get; set; }

        [Required]
        [MaxLength(ProductDescriptionMaxLength)]
        [Comment("Description contains general information about the product.")]
        public string Description { get; set; }

        [Required]
        [Comment("Product's stock quantity shows how many of the same product are left on stock.")]
        public int StockQuantity { get; set; }

        [Required]
        [Comment("Picture or visual representation of the product.")]
        public string ImageUrl { get; set; }

        [Comment("Specifications associated with this product.")]
        public ICollection<Specification> Specifications { get; set; }

        [Comment("Products added to shopping carts by users.")]
        public ICollection<CartProduct> CartProducts { get; set; }

        [Comment("Products added to wishlists by users.")]
        public ICollection<Wishlist> Wishlists { get; set; }

        [Comment("Motorcycles compatible with this product.")]
        public ICollection<MotorcycleProduct> MotorcycleParts { get; set; }
    }
}
