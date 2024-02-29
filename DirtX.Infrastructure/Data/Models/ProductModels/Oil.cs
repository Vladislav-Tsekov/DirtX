using DirtX.Infrastructure.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace DirtX.Infrastructure.Data.Models.ProductModels
{
    public class Oil : Product
    {
        public OilType Type { get; set; }

        [Required]
        public double PackageSize { get; set; }

        public List<PropertyOfOil> Specifications { get; set; }
    }
}
