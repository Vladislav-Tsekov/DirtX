using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DirtX.Scraper.Data.Models
{
    public class Make
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        [Comment("Motorcycle's Make - Manufacturer's Title")]
        public string Title { get; set; }
    }
}
