using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DirtX.Infrastructure.Data.Models.ProductModels.Properties
{
    public abstract class Property
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey(nameof(NameId))]
        public PropertyNames Name { get; set; }
        public int NameId { get; set; }

        [Required]
        public string Value { get; set; }
    }
}
