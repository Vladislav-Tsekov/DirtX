using DirtX.Infrastructure.Data.Models.Products;
using DirtX.Infrastructure.Data.Models.Products.Properties;
using System.ComponentModel.DataAnnotations.Schema;

namespace DirtX.Infrastructure.Data.Models
{
    public class PartProperty
    {
        [ForeignKey(nameof(SpecificationId))]
        public PartSpecification Specification { get; set; }
        public int SpecificationId { get; set; }

        [ForeignKey(nameof(PartId))]
        public Part Part { get; set; }
        public int PartId { get; set; }
    }
}
