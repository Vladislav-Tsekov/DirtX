using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static DirtX.Infrastructure.Shared.ValidationConstants;

namespace DirtX.Infrastructure.Data.Models.Products
{
    public class Specification
    {
        [Key]
        [Comment("Identifier for the specification.")]
        public int Id { get; set; }

        [Required]
        [MaxLength(SpecificationTitleMaxLength)]
        [Comment("The title or name of the specification.")]
        public string Title { get; set; }

        [Required]
        [MaxLength(SpecificationValueMaxLength)]
        [Comment("The value of the specification.")]
        public string Value { get; set; }

        [Comment("Collection of products associated with this specification.")]
        public ICollection<Product> Products { get; set; } = new HashSet<Product>();
    }
}
