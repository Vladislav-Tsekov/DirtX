using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static DirtX.Infrastructure.Shared.ValidationConstants;

namespace DirtX.Infrastructure.Data.Models.Products
{
    public class Specification
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(TitleId))]
        public SpecificationTitle Title { get; set; }
        public int TitleId { get; set; }

        [Required]
        [MaxLength(SpecificationValueMaxLength)]
        public string Value { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
