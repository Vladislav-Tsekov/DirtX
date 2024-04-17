using System.ComponentModel.DataAnnotations;
using static DirtX.Infrastructure.Shared.ValidationConstants;

namespace DirtX.Web.Models
{
    public class CartFormViewModel
    {
        public int Id { get; set; }

        [Range(typeof(decimal), ProductMinPrice, ProductMaxPrice, ConvertValueInInvariantCulture = true)]
        public decimal TotalPrice { get; set; }

        public ICollection<CartProductViewModel> Products { get; set; } = new HashSet<CartProductViewModel>();
    }
}
