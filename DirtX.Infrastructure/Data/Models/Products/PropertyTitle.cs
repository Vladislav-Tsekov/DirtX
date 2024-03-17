using System.ComponentModel.DataAnnotations;

namespace DirtX.Infrastructure.Data.Models.Products
{
    public class PropertyTitle
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
    }
}
