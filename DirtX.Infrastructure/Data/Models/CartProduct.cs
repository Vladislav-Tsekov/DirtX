using DirtX.Infrastructure.Data.Models.Orders;
using DirtX.Infrastructure.Data.Models.Products;
using System.ComponentModel.DataAnnotations.Schema;

namespace DirtX.Infrastructure.Data.Models
{
    public class CartProduct
    {
        public CartProduct()
        {
            Quantity = 1;
        }

        [ForeignKey(nameof(CartId))]
        public Cart Cart { get; set; }
        public Guid CartId { get; set; }

        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; }
        public int ProductId { get; set; }

        public int Quantity { get; set; }
    }
}
