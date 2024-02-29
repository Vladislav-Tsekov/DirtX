using System.ComponentModel.DataAnnotations;

namespace DirtX.Infrastructure.Data.Models.ProductModels
{
    public class PropertyNames
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
