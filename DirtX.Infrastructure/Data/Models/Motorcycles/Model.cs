using System.ComponentModel.DataAnnotations;

namespace DirtX.Infrastructure.Data.Models.Motorcycles
{
    public class Model
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(40)]
        public string Title { get; set; }
    }
}
