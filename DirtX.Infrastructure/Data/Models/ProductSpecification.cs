using DirtX.Infrastructure.Data.Models.Products;
using System.ComponentModel.DataAnnotations.Schema;

namespace DirtX.Infrastructure.Data.Models
{
    public class ProductSpecification
    {
        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; }
        public int ProductId { get; set; }

        [ForeignKey(nameof(SpecificationId))]
        public Specification Specification { get; set; }
        public int SpecificationId { get; set; } 
    }
}
