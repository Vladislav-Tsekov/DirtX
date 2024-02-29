using System.ComponentModel.DataAnnotations.Schema;

namespace DirtX.Infrastructure.Data.Models.ProductModels.Properties
{
    public class PartSpecification
    {
        [ForeignKey(nameof(PartId))]
        public Part Part { get; set; }
        public int PartId { get; set; }

        public List<PartProperty> PartProperties { get; set; }
    }
}
