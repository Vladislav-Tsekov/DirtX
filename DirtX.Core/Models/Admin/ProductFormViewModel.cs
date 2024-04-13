using DirtX.Infrastructure.Data.Models;
using DirtX.Infrastructure.Data.Models.Enums;
using DirtX.Infrastructure.Data.Models.Mappings;
using DirtX.Infrastructure.Data.Models.Products;
using System.ComponentModel.DataAnnotations;

namespace DirtX.Core.Models.Admin
{
    public class ProductFormViewModel
    {
        //TODO - FIX VALUES FOR ATTRIBUTES
        [Required]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Invalid Title")]
        public string Title { get; set; }

        [Required]
        [StringLength(500, MinimumLength = 1, ErrorMessage = "Invalid Description")]
        public string Description { get; set; }

        [Range(typeof(decimal), "1.0m", "3.3m", ErrorMessage = "Invalid Price")]
        public decimal Price { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required(ErrorMessage = "Please select the product's brand.")]
        public ICollection<ProductBrand> Brands { get; set; }

        public ProductBrand Brand { get; set; }

        [Required(ErrorMessage = "Please select the product's type.")]
        public ICollection<ProductType> Types { get; set; }

        public ProductType Type { get; set; }

        [Required(ErrorMessage = "Please select the product's category.")]
        public ProductCategory? Category { get; set; }

        [Required]
        public int StockQuantity { get; set; }

        public ICollection<Specification> Specifications { get; set; }

        public ICollection<MotorcycleProduct> MotorcycleParts { get; set; }
    }
}
