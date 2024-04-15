using DirtX.Infrastructure.Data.Models.Products;

namespace DirtX.Core.Models.Admin
{
    public class LinkSpecProductViewModel
    {
        public int ProductId { get; set; }
        public ICollection<Specification> Specifications { get; set; } = new HashSet<Specification>();
    }
}
