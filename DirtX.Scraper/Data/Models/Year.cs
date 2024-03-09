using System.ComponentModel.DataAnnotations;

namespace DirtX.Scraper.Data.Models
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
