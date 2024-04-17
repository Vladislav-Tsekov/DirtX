using System.ComponentModel.DataAnnotations;
using static DirtX.Infrastructure.Shared.ValidationConstants;

namespace DirtX.Core.Models
{
    public class OrderFormViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(UserFirstNameMaxLength, MinimumLength = UserFirstNameMinLength, ErrorMessage = LengthMustBeBetween)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(UserLastNameMaxLength, MinimumLength = UserLastNameMinLength, ErrorMessage = LengthMustBeBetween)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [StringLength(UserCityMaxLength, MinimumLength = UserCityMinLength, ErrorMessage = LengthMustBeBetween)]
        public string City { get; set; }

        [Required]
        [StringLength(UserAddressMaxLength, MinimumLength = UserAddressMinLength, ErrorMessage = LengthMustBeBetween)]
        public string Address { get; set; }

        public string UserId { get; set; }

        public int CartId { get; set; }

        [Range(typeof(decimal), ProductMinPrice, ProductMaxPrice, ConvertValueInInvariantCulture = true)]
        public decimal TotalPrice { get; set; }
    }
}
