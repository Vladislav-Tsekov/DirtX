using DirtX.Infrastructure.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace DirtX.Infrastructure.Data.Models.Products
{
    public class Oil : Product
    {
        public OilType OilType { get; set; }

        [Required]
        public double PackageSize { get; set; }
        //TODO - IS IT BETTER TO MOVE THE PACKAGE SIZE TO SPECIFICATIONS?
    }
}
