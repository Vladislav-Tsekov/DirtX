using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DirtX.Infrastructure.Data.Models.ProductModels
{
    public class OilSpec
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Value { get; set; }

        [ForeignKey(nameof(OilId))]
        public Oil Oil { get; set; }
        public int OilId { get; set; }
    }
}
