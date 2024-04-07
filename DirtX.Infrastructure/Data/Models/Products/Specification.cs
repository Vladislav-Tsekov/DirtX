using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static DirtX.Infrastructure.Shared.ValidationConstants;
using Microsoft.EntityFrameworkCore;

namespace DirtX.Infrastructure.Data.Models.Products
{
    public class Specification
    {
        [Key]
        [Comment("Identifier for the specification.")]
        public int Id { get; set; }

        [ForeignKey(nameof(TitleId))]
        [Comment("The title or name of the specification.")]
        public SpecificationTitle Title { get; set; }
        public int TitleId { get; set; }

        [Required]
        [MaxLength(SpecificationValueMaxLength)]
        [Comment("The value of the specification.")]
        public string Value { get; set; }

        [Comment("Collection of products associated with this specification.")]
        public ICollection<Product> Products { get; set; }
    }
}
