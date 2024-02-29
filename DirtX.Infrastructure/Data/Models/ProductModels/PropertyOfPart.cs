using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DirtX.Infrastructure.Data.Models.ProductModels
{
    public class PropertyOfPart
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey(nameof(NameId))]
        public PropertyNames Name { get; set; }
        public int NameId { get; set; }

        [Required]
        public string Value { get; set; }

        [ForeignKey(nameof(PartId))]
        public Part Part { get; set; }
        public int PartId { get; set; }
    }
}
