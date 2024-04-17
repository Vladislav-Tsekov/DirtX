using System.ComponentModel.DataAnnotations;
using static DirtX.Infrastructure.Shared.ValidationConstants;

namespace DirtX.Core.Models.Admin
{
    public class BrandFormViewModel
    {
        [Required]
        [StringLength(BrandNameMaxLength, MinimumLength = BrandNameMinLength, ErrorMessage = LengthMustBeBetween)]
        public string Name { get; set; }

        [Required]
        [MaxLength(BrandDescriptionMaxLength)]
        [StringLength(BrandDescriptionMaxLength, MinimumLength = BrandDescriptionMinLength, ErrorMessage = LengthMustBeBetween)]
        public string Description { get; set; }

        [Required]
        [StringLength(ImageMaxLength, MinimumLength = ImageMinLength, ErrorMessage = LengthMustBeBetween)]
        public string ImageUrl { get; set; }
    }
}
