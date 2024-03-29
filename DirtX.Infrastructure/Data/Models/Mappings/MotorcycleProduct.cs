using DirtX.Infrastructure.Data.Models.Motorcycles;
using DirtX.Infrastructure.Data.Models.Products;
using System.ComponentModel.DataAnnotations.Schema;

namespace DirtX.Infrastructure.Data.Models
{
    public class MotorcycleProduct
    {
        [ForeignKey(nameof(MotorcycleId))]
        public Motorcycle Motorcycle { get; set; }
        public int MotorcycleId { get; set; }

        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; }
        public int ProductId { get; set; }
    }
}
