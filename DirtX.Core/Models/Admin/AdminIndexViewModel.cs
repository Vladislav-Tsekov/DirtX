using DirtX.Infrastructure.Data.Models.Products;

namespace DirtX.Core.Models.Admin
{
    public class AdminIndexViewModel
    {
        public ICollection<UserViewModel> Users { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
