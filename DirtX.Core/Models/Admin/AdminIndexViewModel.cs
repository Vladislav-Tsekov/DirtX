namespace DirtX.Core.Models.Admin
{
    public class AdminIndexViewModel
    {
        public IEnumerable<UserViewModel> Users { get; set; }

        public IEnumerable<ProductViewModel> Products { get; set; }
    }
}
