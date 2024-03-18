using System.ComponentModel.DataAnnotations;

namespace DirtX.Infrastructure.Data.Models.Products
{
    public class SpecificationTitle
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
    }
}
