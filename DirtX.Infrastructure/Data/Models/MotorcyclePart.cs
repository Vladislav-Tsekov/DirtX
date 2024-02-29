using DirtX.Infrastructure.Data.Models.MotorcycleSpecs;
using DirtX.Infrastructure.Data.Models.ProductModels;
using System.ComponentModel.DataAnnotations.Schema;

namespace DirtX.Infrastructure.Data.Models
{
    public class MotorcyclePart
    {
        [ForeignKey(nameof(MotorcycleId))]
        public Motorcycle Motorcycle { get; set; }
        public int MotorcycleId { get; set; }

        [ForeignKey(nameof(PartId))]
        public Part Part { get; set; }
        public int PartId { get; set; }
    }
}
