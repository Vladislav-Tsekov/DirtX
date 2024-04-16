using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DirtX.Scraper.Data.Models
{
    public class ScraperInfo
    {
        [Key]
        [Comment("The last known date when the scraper was used to crawl the web.")]
        public DateTime LastRunDate { get; set; }
    }
}
