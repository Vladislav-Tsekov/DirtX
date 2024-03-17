using System.ComponentModel.DataAnnotations;

namespace DirtX.Infrastructure.Data.Models.MotorcycleData
{
    public class Year
    {        
        [Key]
        public int Id { get; set; }

        [Required]
        [Range(1980, 2024)]
        public int ManufactureYear { get; set; }
    }
}
