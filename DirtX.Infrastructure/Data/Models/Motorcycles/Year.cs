using System.ComponentModel.DataAnnotations;
using static DirtX.Infrastructure.Shared.ValidationConstants;

namespace DirtX.Infrastructure.Data.Models.Motorcycles
{
    public class Year
    {        
        [Key]
        public int Id { get; set; }

        [Required]
        [Range(YearMinRange, YearMaxRange)]
        public int ManufactureYear { get; set; }
    }
}
