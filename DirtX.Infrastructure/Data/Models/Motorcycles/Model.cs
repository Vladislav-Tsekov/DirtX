using System.ComponentModel.DataAnnotations;
using static DirtX.Infrastructure.Shared.ValidationConstants;

namespace DirtX.Infrastructure.Data.Models.Motorcycles
{
    public class Model
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ModelTitleMaxLength)]
        public string Title { get; set; }
    }
}
