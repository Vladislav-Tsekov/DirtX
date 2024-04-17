using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace DirtX.Core.Models
{
    public class EditProfileViewModel
    {
        //TODO - CLIENT VALIDATION

        [Required]
        public string Id { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string Address { get; set; }

        public byte[] ProfilePicture { get; set; }

        public IFormFile NewProfilePicture { get; set; }
    }
}
