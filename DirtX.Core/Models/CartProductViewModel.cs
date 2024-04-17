using System.ComponentModel.DataAnnotations;
using static DirtX.Infrastructure.Shared.ValidationConstants;

namespace DirtX.Web.Models
{
    public class CartProductViewModel
    {
        public int ProductId { get; set; }

        public string Title { get; set; }

        public string Image { get; set; }

        public decimal Price { get; set; }

        [Range(ProductQtyMin, ProductQtyMax)]
        public int Quantity { get; set; }

        [Range(typeof(decimal), ProductMinPrice, ProductMaxPrice, ConvertValueInInvariantCulture = true)]
        public decimal TotalPrice { get; set; }
    }
}
