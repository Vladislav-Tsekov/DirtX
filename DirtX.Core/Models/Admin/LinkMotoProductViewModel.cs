using DirtX.Infrastructure.Data.Models.Motorcycles;
using DirtX.Infrastructure.Data.Models.Products;

namespace DirtX.Core.Models.Admin
{
    public class LinkMotoProductViewModel
    {
        public int ProductId { get; set; }
        public ICollection<Motorcycle> Motorcycles { get; set; } = new HashSet<Motorcycle>();
    }
}
