using DirtX.Infrastructure.Data.Models.Products;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DirtX.Infrastructure.Data.Models.Orders
{
    public class Wishlist
    {
        [Key]
        public int Id { get; set; }

        //[Required]
        //[ForeignKey(nameof(UserId))]
        //public ApplicationUser User { get; set; }
        //public string UserId { get; set; }

        //TODO - IMPLEMENT USER

        [Required]
        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; }
        public int ProductId { get; set; }

    }
}
