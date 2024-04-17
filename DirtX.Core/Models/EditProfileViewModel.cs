using System.ComponentModel.DataAnnotations;
using static DirtX.Infrastructure.Shared.ValidationConstants;

namespace DirtX.Core.Models
{
    public class EditProfileViewModel
    {
        [Required]
        public string Id { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [StringLength(UserFirstNameMaxLength, MinimumLength = UserFirstNameMinLength, ErrorMessage = LengthMustBeBetween)]
        public string FirstName { get; set; }

        [StringLength(UserLastNameMaxLength, MinimumLength = UserLastNameMinLength, ErrorMessage = LengthMustBeBetween)]
        public string LastName { get; set; }

        [StringLength(UserCountryMaxLength, MinimumLength = UserCountryMinLength, ErrorMessage = LengthMustBeBetween)]
        public string Country { get; set; }

        [StringLength(UserCityMaxLength, MinimumLength = UserCityMinLength, ErrorMessage = LengthMustBeBetween)]
        public string City { get; set; }

        [StringLength(UserAddressMaxLength, MinimumLength = UserAddressMinLength, ErrorMessage = LengthMustBeBetween)]
        public string Address { get; set; }
    }
}
