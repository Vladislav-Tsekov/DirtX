using System.ComponentModel.DataAnnotations;

namespace DirtX.Web.Models
{
    public class CartProductViewModel
    {
        public CartProductViewModel()
        {
            Quantity = 0;
            TotalPrice = Price * Quantity;
        }

        public int ProductId { get; set; }

        public string Title { get; set; } = null!;

        //TODO - CHANGE THIS IF IMAGES WILL BE HANDLED IN DB
        public string Image { get; set; }

        public decimal Price { get; set; }

        [Range(1, 100)]
        public int Quantity { get; set; }

        [Range(0, int.MaxValue)]
        public decimal TotalPrice { get; set; }
    }
}
