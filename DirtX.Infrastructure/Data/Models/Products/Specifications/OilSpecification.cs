using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DirtX.Infrastructure.Data.Models.ProductModels.Properties
{
    public class OilSpecification : ProductSpecification
    {
        [ForeignKey(nameof(OilId))]
        public Oil Oil { get; set; }
        public int OilId { get; set; }

        public List<OilProperty> OilProperties { get; set; }
    }
}
