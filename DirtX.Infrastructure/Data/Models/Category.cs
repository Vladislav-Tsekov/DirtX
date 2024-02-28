using System.ComponentModel.DataAnnotations;

namespace DirtX.Infrastructure.Data.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public List<Part> Parts { get; set; }
    }
}
