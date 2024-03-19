using DirtX.Infrastructure.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace DirtX.Infrastructure.Data.Models.Products
{
    public class Gear : Product
    {
        [Required]
        public GearSize GearSize { get; set; }

        [Required]
        public GearType GearType { get; set; }
    }
}
