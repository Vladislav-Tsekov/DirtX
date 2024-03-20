using System.ComponentModel.DataAnnotations;

namespace DirtX.Infrastructure.Data.Models.Orders
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }

        //[ForeignKey(nameof(UserId))]
        //public ApplicationUser User { get; set; }
        //public string UserId { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        public ICollection<CartProduct> CartProducts { get; set; }
    }
}
