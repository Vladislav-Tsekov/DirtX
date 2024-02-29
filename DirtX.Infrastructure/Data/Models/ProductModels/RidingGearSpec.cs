using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DirtX.Infrastructure.Data.Models.ProductModels
{
    public class RidingGearSpec
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Value { get; set; }

        [ForeignKey(nameof(RidingGearId))]
        public RidingGear RidingGear { get; set; }
        public int RidingGearId { get; set; }
    }
}
