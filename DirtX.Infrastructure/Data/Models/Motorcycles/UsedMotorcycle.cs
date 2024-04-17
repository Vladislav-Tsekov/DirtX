using DirtX.Infrastructure.Data.Models.Enums;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static DirtX.Infrastructure.Shared.ValidationConstants;

namespace DirtX.Infrastructure.Data.Models.Motorcycles
{
    public class UsedMotorcycle
    {
        [Key]
        [Comment("Used motorcycle identifier.")]
        public int Id { get; set; }

        [ForeignKey(nameof(MakeId))]
        [Comment("Brand or manufacturer of the motorcycle.")]
        public Make Make { get; set; }
        public int MakeId { get; set; }

        [ForeignKey(nameof(ModelId))]
        [Comment("Variant of a motorcycle within a particular make.")]
        public Model Model { get; set; }
        public int ModelId { get; set; }

        [ForeignKey(nameof(DisplacementId))]
        [Comment("Engine displacement volume in cubic centimeters.")]
        public Displacement Displacement { get; set; }
        public int DisplacementId { get; set; }

        [ForeignKey(nameof(YearId))]
        [Comment("Motorcycle's year of manufacture.")]
        public Year Year { get; set; }
        public int YearId { get; set; }

        [Required]
        [Range(UsedMotoMinPrice, UsedMotoMaxPrice)]
        [Comment("Represents the price of the used motorcycle and is set by the user.")]
        public int Price { get; set; }

        [MaxLength(ImageMaxSize)]
        [Comment("Visual representation of the used motorcycle.")]
        public byte[] Image { get; set; }

        [Required]
        [Comment("Location of the used motorcycle - seller's location.")]
        public Province Province { get; set; }

        [Required]
        [MaxLength(UsedMotoDescriptionMaxLength)]
        [Comment("Used motorcycle description, containing information about the vehicle's condition.")]
        public string Description { get; set; }

        [Required]
        [RegularExpression(UsedMotoContactRegEx)]
        [Comment("Telephone number of the seller.")]
        public string Contact { get; set; }
    }
}
