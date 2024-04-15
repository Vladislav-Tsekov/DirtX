using DirtX.Infrastructure.Data.Models;
using DirtX.Infrastructure.Data.Models.Enums;
using DirtX.Infrastructure.Data.Models.Products;
using System.ComponentModel.DataAnnotations;

namespace DirtX.Core.Models.Admin
{
    public class ProductFormViewModel
    {
        [Required(ErrorMessage = "Title is required.")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "{0} length must be between {2} and {1}.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        [StringLength(500, MinimumLength = 20, ErrorMessage = "{0} length must be between {2} and {1}.")]
        public string Description { get; set; }

        [Required]
        [Range(typeof(decimal), "0", "99999", ErrorMessage = "{0} value must be between {1} and {2}.")]
        public decimal Price { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required(ErrorMessage = "Please select the product's brand.")]
        public ICollection<ProductBrand> Brands { get; set; } = new HashSet<ProductBrand>();

        public int BrandId { get; set; }

        [Required(ErrorMessage = "Please select the product's type.")]
        public ICollection<ProductType> Types { get; set; } = new HashSet<ProductType>();

        public int TypeId { get; set; }

        [Required(ErrorMessage = "Please select the product's category.")]
        public ProductCategory? Category { get; set; }

        [Required]
        [Range(0, 999, ErrorMessage = "{0} value must be between {1} and {2}.")]
        public int StockQuantity { get; set; }

        public ICollection<Specification> Specifications { get; set; }

        public ICollection<MotorcycleProduct> MotorcycleParts { get; set; }
    }
}
