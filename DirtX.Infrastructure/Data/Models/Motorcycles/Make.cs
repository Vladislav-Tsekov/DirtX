using System.ComponentModel.DataAnnotations;

namespace DirtX.Infrastructure.Data.Models.Motorcycles
{
    public class Make
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
    }
}
