namespace DirtX.Core.Models.Admin
{
    public class AdminIndexViewModel
    {
        public ICollection<UserViewModel> Users { get; set; }
        public ICollection<ProductViewModel> Products { get; set; }
    }
}
