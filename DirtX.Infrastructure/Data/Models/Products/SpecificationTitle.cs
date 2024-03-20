using System.ComponentModel.DataAnnotations;
using static DirtX.Infrastructure.Shared.ValidationConstants;

namespace DirtX.Infrastructure.Data.Models.Products
{
    public class SpecificationTitle
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(SpecificationTitleMaxLength)]
        public string Title { get; set; }
    }
}
