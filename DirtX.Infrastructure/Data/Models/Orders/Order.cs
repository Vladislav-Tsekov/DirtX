using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DirtX.Infrastructure.Data.Models.Orders
{
    public class Order
    {
        public Order()
        {
            Id = Guid.NewGuid();
            DateCreated = DateTime.Now;
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal TotalPrice { get; set; }

        [ForeignKey(nameof(UserId))]
        public AppUser User { get; set; }
        public Guid UserId { get; set; }

        [ForeignKey(nameof(CartId))]
        public Cart Cart { get; set; }
        public Guid CartId { get; set; }
    }
}
