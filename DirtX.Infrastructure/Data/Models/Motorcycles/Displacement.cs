using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static DirtX.Infrastructure.Shared.ValidationConstants;

namespace DirtX.Infrastructure.Data.Models.Motorcycles
{
    [Comment("Motorcycle displacement.")]
    public class Displacement
    {
        [Key]
        [Comment("Identifier for motorcycle displacement.")]
        public int Id { get; set; }

        [Required]
        [Range(EngineVolumeMin, EngineVolumeMax)]
        [Comment("Engine displacement volume in cubic centimeters.")]
        public int Volume { get; set; }
    }
}
