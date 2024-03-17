using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DirtX.Infrastructure.Data.Models.MotorcycleData
{
    public class Motorcycle
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey(nameof(MakeId))]
        public Make Make { get; set; }
        public int MakeId { get; set; }

        [Required]
        [ForeignKey(nameof(ModelId))]
        public Model Model { get; set; }
        public int ModelId { get; set; }

        [Required]
        [ForeignKey(nameof(YearId))]
        public Year Year { get; set; }
        public int YearId { get; set; }

        [Required]
        [ForeignKey(nameof(DisplacementId))]
        public Displacement Displacement { get; set; }
        public int DisplacementId { get; set; }

        public List<MotorcyclePart> MotorcycleParts { get; set; }

        //TODO - CHECK WHETHER ADDITIONAL VALIDATIONS WILL BE REQUIRED FOR MAKE/MODEL RELATIONSHIP.
        //public IEnumerable<ValidationResult> Validate(ValidationContext validationContext) 
        //{
        
        //}
    }
}
