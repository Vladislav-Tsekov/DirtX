using DirtX.Infrastructure.Data.Models.ProductModels;
using DirtX.Infrastructure.Data.Models.ProductModels.Properties;
using System.ComponentModel.DataAnnotations.Schema;

namespace DirtX.Infrastructure.Data.Models
{
    public class PartProperty
    {
        [ForeignKey(nameof(PropertyId))]
        public PartSpecification Specification { get; set; }
        public int PropertyId { get; set; }

        [ForeignKey(nameof(PartId))]
        public Part Part { get; set; }
        public int PartId { get; set; }
    }
}
