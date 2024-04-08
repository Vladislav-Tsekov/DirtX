using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DirtX.Infrastructure.Data.Models.Users
{
    public class Order
    {
        public Order()
        {
            DateCreated = DateTime.Now;
        }

        [Key]
        [Comment("Identifier for the order.")]
        public int Id { get; set; }

        [Required]
        [Comment("First name of the customer.")]
        public string FirstName { get; set; }

        [Required]
        [Comment("Last name of the customer.")]
        public string LastName { get; set; }

        [Required]
        [Comment("Address where the order is to be delivered.")]
        public string Address { get; set; }

        [Required]
        [Comment("City where the order is to be delivered.")]
        public string City { get; set; }

        [Required]
        [Comment("Date and time when the order was created.")]
        public DateTime DateCreated { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        [Comment("Total price of the order.")]
        public decimal TotalPrice { get; set; }

        [ForeignKey(nameof(UserId))]
        [Comment("The user who placed the order.")]
        public AppUser User { get; set; }
        public string UserId { get; set; }

        [ForeignKey(nameof(CartId))]
        [Comment("The cart associated with the order.")]
        public Cart Cart { get; set; }
        public int CartId { get; set; }
    }
}
