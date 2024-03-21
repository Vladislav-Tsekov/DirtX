using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace DirtX.Core.Validation
{
    public class MaxFileSizeAttribute : ValidationAttribute
    {
        private readonly int maxFileSize;

        public MaxFileSizeAttribute(int _maxFileSize)
        {
            maxFileSize = _maxFileSize;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is IFormFile file)
            {
                if (file.Length > maxFileSize)
                {
                    return new ValidationResult($"The file size must not exceed {maxFileSize / 1024 / 1024}MB.");
                }
            }

            return ValidationResult.Success;
        }
    }
}
