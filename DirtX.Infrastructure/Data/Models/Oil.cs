using DirtX.Infrastructure.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace DirtX.Infrastructure.Data.Models
{
    public class Oil : Product
    {
        public OilType Type { get; set; }

        [Required]
        public string PackageSize { get; set; }
    }
}
