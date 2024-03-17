using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DirtX.Infrastructure.Data.Models.Products
{
    public abstract class ProductProperty
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey(nameof(TitleId))]
        public PropertyTitle Title { get; set; }
        public int TitleId { get; set; }

        [Required]
        public string Value { get; set; }
    }
}
