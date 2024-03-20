using DirtX.Infrastructure.Data.Models.Orders;
using DirtX.Infrastructure.Data.Models.Products;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DirtX.Infrastructure.Data.Models
{
    public class CartProduct
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(CartId))]
        public Cart Cart { get; set; }
        public int CartId { get; set; }

        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; }
        public int ProductId { get; set; }
    }
}
