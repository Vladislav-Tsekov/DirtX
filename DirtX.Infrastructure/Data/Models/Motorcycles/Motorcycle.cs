using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DirtX.Infrastructure.Data.Models.Motorcycles
{
    public class Motorcycle
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(MakeId))]
        public Make Make { get; set; }
        public int MakeId { get; set; }

        [ForeignKey(nameof(ModelId))]
        public Model Model { get; set; }
        public int ModelId { get; set; }

        [ForeignKey(nameof(YearId))]
        public Year Year { get; set; }
        public int YearId { get; set; }

        [ForeignKey(nameof(DisplacementId))]
        public Displacement Displacement { get; set; }
        public int DisplacementId { get; set; }

        //TODO - CHECK COMPATIBILITY WITH GARAGE?
        //[ForeignKey(nameof(GarageId))]
        //public Garage Garage { get; set; }
        //public int GarageId { get; set; }

        public List<MotorcyclePart> MotorcycleParts { get; set; }
    }
}
