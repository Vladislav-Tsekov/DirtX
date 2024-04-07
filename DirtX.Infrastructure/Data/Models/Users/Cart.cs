using DirtX.Infrastructure.Data.Models.Mappings;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DirtX.Infrastructure.Data.Models.Users
{
    public class Cart
    {
        [Key]
        [Comment("Identifier for the cart.")]
        public int Id { get; set; }

        [ForeignKey(nameof(UserId))]
        [Comment("The user who owns the cart.")]
        public AppUser User { get; set; }
        public string UserId { get; set; }

        [Required]
        [Comment("Date and time when the cart was created.")]
        public DateTime DateCreated { get; set; }

        [Comment("Products added to the cart.")]
        public ICollection<CartProduct> CartProducts { get; set; }
    }

}
