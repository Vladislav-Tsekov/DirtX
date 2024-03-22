using DirtX.Infrastructure.Data.Models.Motorcycles;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DirtX.Infrastructure.Data.Models
{
    public class Garage
    {
        [Key]
        [ForeignKey(nameof(UserId))]
        public Guid UserId { get; set; }
        public AppUser User { get; set; }

        [Range(0, 10)]
        public int MotoCount { get; set; }

        public byte[] Image { get; set; }

        public ICollection<Motorcycle> Motorcycles { get; set; }
    }
}
