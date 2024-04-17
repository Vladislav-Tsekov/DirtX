using System.ComponentModel.DataAnnotations;

namespace DirtX.Core.Models
{


    public class OrderFormViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "InvalidFirstName")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "InvalidFirstName")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "InvalidCountry")]
        public string City { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "InvalidAddress")]
        public string Address { get; set; }

        public string UserId { get; set; }

        public int CartId { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
