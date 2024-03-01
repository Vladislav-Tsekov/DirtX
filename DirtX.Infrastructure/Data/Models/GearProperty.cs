using DirtX.Infrastructure.Data.Models.ProductModels;
using DirtX.Infrastructure.Data.Models.ProductModels.Properties;
using System.ComponentModel.DataAnnotations.Schema;

namespace DirtX.Infrastructure.Data.Models
{
    public class GearProperty
    {
        [ForeignKey(nameof(SpecificationId))]
        public GearSpecification Specification { get; set; }
        public int SpecificationId { get; set; }

        [ForeignKey(nameof(GearId))]
        public Gear Gear { get; set; }
        public int GearId { get; set; }
    }
}
