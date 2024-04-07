using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DirtX.Infrastructure.Data.Models.Users
{
    public class AppUser : IdentityUser
    {
        [MaxLength(50)]
        [Comment("First name of the user.")]
        public string FirstName { get; set; }

        [MaxLength(50)]
        [Comment("Last name of the user.")]
        public string LastName { get; set; }

        [MaxLength(100)]
        [Comment("Country where the user resides.")]
        public string Country { get; set; }

        [MaxLength(300)]
        [Comment("City where the user resides.")]
        public string City { get; set; }

        [MaxLength(100)]
        [Comment("Address of the user.")]
        public string Address { get; set; }

        [Comment("Profile picture of the user.")]
        public byte[] ProfilePicture { get; set; }

        [Comment("Indicates whether the user has admin privileges.")]
        public bool IsAdmin { get; set; }

        [Comment("Indicates whether the user is a reseller.")]
        public bool IsReseller { get; set; }

        [Comment("Date and time when the user account was created.")]
        public DateTime CreatedOn { get; set; }

        [Comment("Orders placed by the user.")]
        public ICollection<Order> Orders { get; set; } = new List<Order>();

        [Comment("Shopping carts belonging to the user.")]
        public ICollection<Cart> Carts { get; set; } = new List<Cart>();

        [Comment("Garage associated with the user.")]
        public Garage Garage { get; set; } = new Garage();
    }

}
