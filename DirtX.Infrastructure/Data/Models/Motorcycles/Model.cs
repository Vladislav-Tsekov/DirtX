using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static DirtX.Infrastructure.Shared.ValidationConstants;

namespace DirtX.Infrastructure.Data.Models.Motorcycles
{
    [Comment("Motorcycle model.")]
    public class Model
    {
        [Key]
        [Comment("Identifier for motorcycle model.")]
        public int Id { get; set; }

        [Required]
        [MaxLength(ModelTitleMaxLength)]
        [Comment("Variant of a motorcycle within a particular make.")]
        public string Title { get; set; }
    }
}
