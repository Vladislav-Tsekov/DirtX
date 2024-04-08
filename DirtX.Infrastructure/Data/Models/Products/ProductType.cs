using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static DirtX.Infrastructure.Shared.ValidationConstants;

namespace DirtX.Infrastructure.Data.Models.Products
{
    public class ProductType
    {
        [Key]
        [Comment("Identifier for the product type.")]
        public int Id { get; set; }

        [Required]
        [MaxLength(ProductTypeTitleMaxLength)]
        [Comment("The name of the product type.")]
        public string Name { get; set; }

        [Required]
        [MaxLength(ProductTypeDescriptionMaxLength)]
        [Comment("Description providing information about the product type.")]
        public string Description { get; set; }
    }
}
