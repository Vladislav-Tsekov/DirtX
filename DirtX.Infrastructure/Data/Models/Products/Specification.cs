using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DirtX.Infrastructure.Data.Models.Products
{
    public class Specification
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey(nameof(TitleId))]
        public SpecificationTitle Title { get; set; }
        public int TitleId { get; set; }

        [Required]
        public string Value { get; set; }

        public List<Product> Products { get; set; }
    }
}
