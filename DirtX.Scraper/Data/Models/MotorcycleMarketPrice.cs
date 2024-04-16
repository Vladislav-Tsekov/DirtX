using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DirtX.Scraper.Data.Models
{
    public class MotorcycleMarketPrice
    {
        [Comment("Motorcycle's Make - Manufacturer")]
        [ForeignKey(nameof(MakeId))]
        public Make Make { get; set; }
        public int MakeId { get; set; }

        [Comment("Motorcycle's Year of manufacture")]
        [ForeignKey(nameof(YearId))]
        public Year Year { get; set; }
        public int YearId { get; set; }

        [Comment("The number of motorcycle announcements for the current make/year combination")]
        public int MotoCount { get; set; }

        [Comment("The Average Price for each make/year combination")]
        [Required]
        public decimal AvgPrice { get; set; }

        [Comment("The Mean Price for each make/year combination, calculated with a trim factor of 0.20")]
        [Required]
        public decimal MeanTrimPrice { get; set; }

        [Comment("The Standard Deviation Price for each make/year combination")]
        [Required]
        public decimal StdDevPrice { get; set; }

        [Comment("The Median Price for each make/year combination")]
        [Required]
        public decimal MedianPrice { get; set; }

        [Comment("The Mode Price (most frequent value, if such exists) for each make/year combination")]
        [Required]
        public decimal ModePrice { get; set; }

        [Comment("The Price Range (most expensive - cheapest announcement) for each make/year combination")]
        [Required]
        public decimal PriceRange { get; set; }

        [Comment("The Price Variance coefficient for each make/year combination")]
        [Required]
        public decimal PriceVariance { get; set; }
    }
}
