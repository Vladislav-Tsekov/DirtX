using System.ComponentModel.DataAnnotations;

namespace DirtX.Web.Models
{
    public class CartFormViewModel
    {
        public int Id { get; set; }

        [Range(0, int.MaxValue)]
        public decimal TotalPrice { get; set; }

        public ICollection<CartProductViewModel> Products { get; set; } = new HashSet<CartProductViewModel>();
    }
}
