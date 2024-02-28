using DirtX.Infrastructure.Data.Models.Enums;
using DirtX.Infrastructure.Data.Models.MotorcycleSpecs;
using System.ComponentModel.DataAnnotations;

namespace DirtX.Infrastructure.Data.Models
{
    public class Part : Product
    {
        [Required]
        public PartType Type { get; set; }

        public List<ProductProperty> Properties { get; set; }
        public List<MotorcyclePart> MotorcycleParts { get; set; }
    }
}
