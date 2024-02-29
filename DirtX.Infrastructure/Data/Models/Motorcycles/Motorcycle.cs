using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DirtX.Infrastructure.Data.Models.MotorcycleSpecs
{
    public class Motorcycle
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(MakeId))]
        public MotoMake Make { get; set; }
        public int MakeId { get; set; }

        [ForeignKey(nameof(ModelId))]
        public MotoModel Model { get; set; }
        public int ModelId { get; set; }

        [ForeignKey(nameof(YearId))]
        public MotoYear Year { get; set; }
        public int YearId { get; set; }

        [ForeignKey(nameof(DisplacementId))]
        public MotoDisplacement Displacement { get; set; }
        public int DisplacementId { get; set; }

        public List<MotorcyclePart> MotorcycleParts { get; set; }

        public bool IsValid()
        {
            if (Make != null && Model != null)
            {
                return Make.IsModelValid(Model);
            }

            return false;
        }
    }
}
