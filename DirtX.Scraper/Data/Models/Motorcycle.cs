using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DirtX.Scraper.Data.Models
{
    public class Motorcycle
    {
        [Key]
        [Comment("Each announcement link is unique, therefore used as a key")]
        public string Link { get; set; }

        [Required]
        [ForeignKey(nameof(MakeId))]
        [Comment("Motorcycle's Make - Manufacturer")]
        public Make Make { get; set; }
        public int MakeId { get; set; }

        [Required]
        [ForeignKey(nameof(YearId))]
        [Comment("Motorcycle's Year of manufacture")]
        public Year Year { get; set; }
        public int YearId { get; set; }

        [Required]
        [Comment("Motorcycle's engine displacement in cubic centimeters")]
        public int Displacement { get; set; }

        [Required]
        [Comment("Motorcycle's actual price")]
        public decimal Price { get; set; }

        [Required]
        [Comment("Announcement's number of price changes")]
        public int PriceChanges { get; set; } = 0;

        [Comment("The price's value before it was changed")]
        public decimal OldPrice { get; set; }

        [Required]
        [Comment("Date of announcement's addition to the database")]
        public DateTime DateAdded { get; set; }

        [Required]
        [Comment("Keeps track whether the motorcycle has been sold")]
        public bool IsSold { get; set; }
    }
}
