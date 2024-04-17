using DirtX.Core.Validation;
using DirtX.Infrastructure.Data.Models.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using static DirtX.Infrastructure.Shared.ValidationConstants;

namespace DirtX.Core.Models
{
    public class SellFormViewModel
    {
        [Required(ErrorMessage = "Please select a make.")]
        public int SelectedMake { get; set; }

        [Required(ErrorMessage = "Please select a model.")]
        public int SelectedModel { get; set; }

        [Required(ErrorMessage = "Please select a year.")]
        public int SelectedYear { get; set; }

        [Required(ErrorMessage = "Please select a displacement.")]
        public int SelectedDisplacement { get; set; }

        [Required(ErrorMessage = "Please enter the price.")]
        [Range(1, int.MaxValue, ErrorMessage = "Price must be a positive number.")]
        public int Price { get; set; }

        public byte[] Image { get; set; }

        [Required(ErrorMessage = "Please select a province.")]
        public Province? Province { get; set; }

        [Required(ErrorMessage = "Please enter a description.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please enter a contact.")]
        [RegularExpression(UsedMotoContactRegEx)]
        public string Contact { get; set; }

        [MaxFileSize(1048576, ErrorMessage = "The file size must not exceed 1MB.")]
        public IFormFile ImageFile { get; set; }

        public IEnumerable<SelectListItem> Makes { get; set; }
    }
}
