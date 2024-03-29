using DirtX.Infrastructure.Data.Models.Products;
using DirtX.Infrastructure.Data.Models.Users;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DirtX.Infrastructure.Data.Models.Mappings
{
    public class Wishlist
    {
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        public AppUser User { get; set; }

        [Required]
        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
