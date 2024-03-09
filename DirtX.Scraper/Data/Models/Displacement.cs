using System.ComponentModel.DataAnnotations;

namespace DirtX.Scraper.Data.Models
{
    public class Displacement
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Range(0, 1000)]
        public int Volume { get; set; }
    }
}
