using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static DirtX.Infrastructure.Shared.ValidationConstants;

namespace DirtX.Infrastructure.Data.Models.Motorcycles
{
    [Comment("Motorcycle make.")]
    public class Make
    {
        [Key]
        [Comment("Identifier for motorcycle make.")]
        public int Id { get; set; }

        [Required]
        [MaxLength(MakeTitleMaxLength)]
        [Comment("Brand or manufacturer of the motorcycle.")]
        public string Title { get; set; }
    }
}
