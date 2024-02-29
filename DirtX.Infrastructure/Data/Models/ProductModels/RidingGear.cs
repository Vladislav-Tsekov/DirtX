using DirtX.Infrastructure.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace DirtX.Infrastructure.Data.Models.ProductModels
{
    public class RidingGear : Product
    {
        [Required]
        public RidingGearSize Size { get; set; }

        [Required]
        public RidingGearType Type { get; set; }

        //TODO - EVALUATE THE NEED TO IMPLEMENT PROPERTY FOR PIECES OF RIDING GEAR, FOLLOWING THE PARTS MODEL
    }
}
