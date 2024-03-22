using DirtX.Infrastructure.Data.Models.Orders;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace DirtX.Infrastructure.Data.Models
{
    public class AppUser : IdentityUser<Guid>
    {
        public AppUser()
        {
            Id = Guid.NewGuid();
            IsAdmin = false;
            IsReseller = false;
            CreatedOn = DateTime.Now;
            Orders = new HashSet<Order>();
        }

        [MaxLength(50)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public string LastName { get; set; }

        [MaxLength(100)]
        public string Country { get; set; }

        [MaxLength(300)]
        public string City { get; set; }

        [MaxLength(100)]
        public string Address { get; set; }

        [MaxLength(15)]
        public string PostCode { get; set; }

        public byte[] ProfilePicture { get; set; }

        public bool IsAdmin { get; set; }

        public bool IsReseller { get; set; }

        public DateTime CreatedOn { get; set; }

        public ICollection<Order> Orders { get; set; }

        public ICollection<Cart> Carts { get; set; }

        public Garage Garage { get; set; }
    }
}
