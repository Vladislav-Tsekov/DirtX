using DirtX.Infrastructure.Data.Models.Users;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DirtX.Infrastructure.Data.Models.Motorcycles
{
    public class Motorcycle
    {
        [Key]
        [Comment("Motorcycle identifier.")]
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

        //[ForeignKey(nameof(GarageId))]
        //[Comment("Indicates whether the current motorcycle is part of the user's garage.")]
        //public Garage Garage { get; set; }
        //public int? GarageId { get; set; }

        [Comment("A list of compatible parts, fitting a specific motorcycle.")]
        public ICollection<MotorcycleProduct> MotorcycleParts { get; set; } = new List<MotorcycleProduct>();
    }
}
