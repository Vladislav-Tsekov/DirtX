using System.ComponentModel.DataAnnotations;

namespace DirtX.Scraper.Data.Models
{
    public class Make
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
    }
}
