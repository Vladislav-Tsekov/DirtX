using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DirtX.Infrastructure.Data.Models.Products.Properties
{
    public abstract class ProductSpecification
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey(nameof(TitleId))]
        public SpecificationTitles Title { get; set; }
        public int TitleId { get; set; }

        [Required]
        public string Value { get; set; }
    }
}
