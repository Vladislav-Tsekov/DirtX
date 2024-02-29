using DirtX.Infrastructure.Data.Models.ProductModels;
using DirtX.Infrastructure.Data.Models.ProductModels.Properties;
using System.ComponentModel.DataAnnotations.Schema;

namespace DirtX.Infrastructure.Data.Models
{
    public class OilProperty
    {
        [ForeignKey(nameof(PropertyId))]
        public OilSpecification Specification { get; set; }
        public int PropertyId { get; set; }

        [ForeignKey(nameof(OilId))]
        public Oil Oil { get; set; }
        public int OilId { get; set; }
    }
}
