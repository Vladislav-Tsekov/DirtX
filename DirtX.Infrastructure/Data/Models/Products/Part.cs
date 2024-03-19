using DirtX.Infrastructure.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace DirtX.Infrastructure.Data.Models.Products
{
    public class Part : Product
    {
        [Required]
        public PartType PartType { get; set; }

        public List<MotorcyclePart> MotorcycleParts { get; set; }
    }
}
