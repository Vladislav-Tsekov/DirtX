using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DirtX.Infrastructure.Data.Models.Products
{
    public class ProductType
    {
        [Key]
        [Comment("Identifier for the product type.")]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        [Comment("The name of the product type.")]
        public string Name { get; set; }

        [Required]
        [MaxLength(1000)]
        [Comment("Description providing information about the product type.")]
        public string Description { get; set; }
    }
}
