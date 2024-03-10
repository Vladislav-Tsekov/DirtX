using System.ComponentModel.DataAnnotations;

namespace DirtX.Scraper.Data.Models
{
    public class Model
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(40)]
        public string Title { get; set; }
    }
}
