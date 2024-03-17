using DirtX.Infrastructure.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DirtX.Infrastructure.Data.Models.Motorcycles
{
    public class UsedMotorcycle
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
        [ForeignKey(nameof(DisplacementId))]
        public Displacement Displacement { get; set; }
        public int DisplacementId { get; set; }

        [Required]
        [ForeignKey(nameof(YearId))]
        public Year Year { get; set; }
        public int YearId { get; set; }

        public int Price { get; set; }

        [Required]
        public byte[] Image { get; set; }
        //TODO - ADD AN ALBUM FOR EVERY USEDMOTO, IF PROJECT IS FINISHED EARLY

        [Required]
        public Province Province { get; set; } 

        public string Description { get; set; }

        [Required]
        public string Contact {  get; set; }
    }
}
