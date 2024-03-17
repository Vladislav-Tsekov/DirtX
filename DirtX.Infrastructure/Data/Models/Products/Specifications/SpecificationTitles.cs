using System.ComponentModel.DataAnnotations;

namespace DirtX.Infrastructure.Data.Models.Products.Properties
{
    public class SpecificationTitles
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
    }
}
