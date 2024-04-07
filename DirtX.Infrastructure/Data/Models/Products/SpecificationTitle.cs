using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static DirtX.Infrastructure.Shared.ValidationConstants;

namespace DirtX.Infrastructure.Data.Models.Products
{
    public class SpecificationTitle
    {
        [Key]
        [Comment("Identifier for the specification title.")]
        public int Id { get; set; }

        [Required]
        [MaxLength(SpecificationTitleMaxLength)]
        [Comment("The title or name of the specification.")]
        public string Title { get; set; }
    }
}
