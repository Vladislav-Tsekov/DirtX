using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DirtX.Infrastructure.Data.Models.ProductModels
{
    public class PropertyOfGear
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey(nameof(NameId))]
        public PropertyNames Name { get; set; }
        public int NameId { get; set; }

        [Required]
        public string Value { get; set; }

        [ForeignKey(nameof(GearId))]
        public Gear Gear { get; set; }
        public int GearId { get; set; }
    }
}
