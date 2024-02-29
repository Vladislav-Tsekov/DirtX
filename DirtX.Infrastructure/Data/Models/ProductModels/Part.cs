using DirtX.Infrastructure.Data.Models.Enums;
using DirtX.Infrastructure.Data.Models.MotorcycleSpecs;
using DirtX.Infrastructure.Data.Models.ProductModels.Properties;
using System.ComponentModel.DataAnnotations;

namespace DirtX.Infrastructure.Data.Models.ProductModels
{
    public class Part : Product
    {
        [Required]
        public PartType Type { get; set; }

        public List<PropertyOfPart> Specifications { get; set; }
        public List<MotorcyclePart> MotorcycleParts { get; set; }
    }
}
