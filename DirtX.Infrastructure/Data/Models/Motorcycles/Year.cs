using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static DirtX.Infrastructure.Shared.ValidationConstants;

namespace DirtX.Infrastructure.Data.Models.Motorcycles
{
    public class Year
    {
        [Key]
        [Comment("Identifier for motorcycle year.")]
        public int Id { get; set; }

        [Required]
        [Range(YearMinRange, YearMaxRange)]
        [Comment("Motorcycle's year of manufacture.")]
        public int ManufactureYear { get; set; }
    }
}
