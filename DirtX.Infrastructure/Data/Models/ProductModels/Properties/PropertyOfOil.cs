using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DirtX.Infrastructure.Data.Models.ProductModels.Properties
{
    public class PropertyOfOil : Property
    {
        [ForeignKey(nameof(OilId))]
        public Oil Oil { get; set; }
        public int OilId { get; set; }
    }
}
