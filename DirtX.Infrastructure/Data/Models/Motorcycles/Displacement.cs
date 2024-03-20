using System.ComponentModel.DataAnnotations;
using static DirtX.Infrastructure.Shared.ValidationConstants;

namespace DirtX.Infrastructure.Data.Models.Motorcycles
{
    public class Displacement
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Range(EngineVolumeMin, EngineVolumeMax)]
        public int Volume { get; set; }
    }
}
