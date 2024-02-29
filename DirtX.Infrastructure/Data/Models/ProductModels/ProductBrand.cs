using System.ComponentModel.DataAnnotations;

namespace DirtX.Infrastructure.Data.Models.ProductModels
{
    public class ProductBrand
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        //TODO - EVALUATE THE NEED TO USE BRAND SEPARATION ON PRODUCT TYPE BASIS, AS FOLLOWS:

        //public BrandCategory Category { get; set; }

        //public enum BrandCategory
        //{
        //    Parts,
        //    RidingGear,
        //    Etc..
        //}
    }
}
