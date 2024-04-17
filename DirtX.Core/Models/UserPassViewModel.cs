using System.ComponentModel.DataAnnotations;

namespace DirtX.Core.Models
{
    public class UserChangePasswordViewModel
    {
        [Required(ErrorMessage = "GeneralRequiredErrorMessage")]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; } = null!;

        [Required(ErrorMessage = "GeneralRequiredErrorMessage")]
        [DataType(DataType.Password)]
        [Display(Name = "New Password")]
        public string NewPassword { get; set; } = null!;

        [Required(ErrorMessage = "GeneralRequiredErrorMessage")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; } = null!;
    }
}
