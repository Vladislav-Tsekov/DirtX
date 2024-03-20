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

        //TODO - COMM DATA BELOW TO BE TAKEN FROM THE IDENTITY / HANDLE NULLABLE SPECIFICATIONS

        //[Required]
        //public string FirstName { get; set; }

        //[Required]
        //public string LastName { get; set; }

        //[Required]
        //public string Address { get; set; }
        //[Required]
        //public string City { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        [Required]
        public decimal TotalPrice { get; set; }

        //[ForeignKey(nameof(UserId))]
        //public ApplicationUser User { get; set; }
        //public string UserId { get; set; }

        [ForeignKey(nameof(CartId))]
        public Cart Cart { get; set; }
        public int CartId { get; set; }
    }
}
