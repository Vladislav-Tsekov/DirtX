using DirtX.Infrastructure.Data.Models.Enums;
using DirtX.Infrastructure.Data.Models.ProductModels.Properties;
using System.ComponentModel.DataAnnotations;

namespace DirtX.Infrastructure.Data.Models.ProductModels
{
    public class Gear : Product
    {
        [Required]
        public GearSize Size { get; set; }

        [Required]
        public GearType Type { get; set; }

        public List<GearProperty> GearProperties { get; set; }
    }
}
