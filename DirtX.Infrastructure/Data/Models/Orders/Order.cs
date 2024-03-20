using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DirtX.Infrastructure.Data.Models.Orders
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

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
