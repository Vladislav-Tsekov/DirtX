using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DirtX.Infrastructure.Data.Models.Orders
{
    public class Cart
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual AppUser User { get; set; }
        public Guid UserId { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        public ICollection<CartProduct> CartProducts { get; set; }
    }
}
