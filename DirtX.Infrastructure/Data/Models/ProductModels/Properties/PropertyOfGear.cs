using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DirtX.Infrastructure.Data.Models.ProductModels.Properties
{
    public class PropertyOfGear : Property
    {
        [ForeignKey(nameof(GearId))]
        public Gear Gear { get; set; }
        public int GearId { get; set; }
    }
}
