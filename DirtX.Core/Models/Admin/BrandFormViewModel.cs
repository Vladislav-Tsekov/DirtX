using System.ComponentModel.DataAnnotations;
using static DirtX.Infrastructure.Shared.ValidationConstants;

namespace DirtX.Core.Models.Admin
{
    public class BrandFormViewModel
    {
        [Required]
        [StringLength(BrandNameMaxLength, MinimumLength = BrandNameMinLength, ErrorMessage = "{0} length must be between {2} and {1}.")]
        public string Name { get; set; }

        [Required]
        [MaxLength(BrandDescriptionMaxLength)]
        [StringLength(BrandDescriptionMaxLength, MinimumLength = BrandDescriptionMinLength, ErrorMessage = "{0} length must be between {2} and {1}.")]
        public string Description { get; set; }

        [Required]
        [StringLength(1000, MinimumLength = 5, ErrorMessage = "{0} length must be between {2} and {1}.")]
        public string ImageUrl { get; set; }
    }
}
