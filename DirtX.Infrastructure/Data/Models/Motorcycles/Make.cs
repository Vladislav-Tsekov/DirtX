using System.ComponentModel.DataAnnotations;
using static DirtX.Infrastructure.Shared.ValidationConstants;

namespace DirtX.Infrastructure.Data.Models.Motorcycles
{
    public class Make
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(MakeTitleMaxLength)]
        public string Title { get; set; }
    }
}
