using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DirtX.Scraper.Data.Models
{
    public class Year
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Range(1980, 2024)]
        [Comment("Motorcycle's Year of manufacture")]
        public int ManufactureYear { get; set; }
    }
}
