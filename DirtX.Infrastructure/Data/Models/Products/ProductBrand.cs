using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static DirtX.Infrastructure.Shared.ValidationConstants;

namespace DirtX.Infrastructure.Data.Models.Products
{
    public class ProductBrand
    {
        [Key]
        [Comment("Product brand identifier.")]
        public int Id { get; set; }

        [Required]
        [MaxLength(BrandNameMaxLength)]
        [Comment("The name of the brand.")]
        public string Name { get; set; }

        [Required]
        [MaxLength(BrandDescriptionMaxLength)]
        [Comment("Description providing information about the product brand.")]
        public string Description { get; set; }

        [Required]
        [Comment("URL pointing to the image representing the product brand.")]
        public string ImageUrl { get; set; }
    }
}
