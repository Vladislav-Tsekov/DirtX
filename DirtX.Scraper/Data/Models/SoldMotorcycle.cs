using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DirtX.Scraper.Data.Models
{
    public class SoldMotorcycle
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(MakeId))]
        [Comment("Motorcycle's Make - Manufacturer")]
        public Make Make { get; set; }
        public int MakeId { get; set; }

        [ForeignKey(nameof(YearId))]
        [Comment("Motorcycle's Year of manufacture")]
        public Year Year { get; set; }
        public int YearId { get; set; }

        [Comment("Motorcycle's engine displacement")]
        public int Displacement { get; set; }

        [Required]
        [Comment("Motorcycle's price")]
        public decimal Price { get; set; }

        [Required]
        [Comment("Date of announcement's addition to the database")]
        public DateTime DateAdded { get; set; }

        [Required]
        [Comment("Date of announcement's removal from the website")]
        public DateTime DateSold { get; set; }
    }
}
