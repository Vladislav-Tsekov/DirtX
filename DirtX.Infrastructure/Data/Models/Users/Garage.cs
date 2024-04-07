using DirtX.Infrastructure.Data.Models.Motorcycles;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DirtX.Infrastructure.Data.Models.Users
{
    public class Garage
    {
        [Key]
        [ForeignKey(nameof(UserId))]
        [Comment("The ID of the user who owns the garage.")]
        public string UserId { get; set; }
        public AppUser User { get; set; }

        [Range(0, 10)]
        [Comment("The maximum number of motorcycles allowed in the garage.")]
        public int MotoCount { get; set; }

        [Comment("Motorcycles stored in the garage.")]
        public ICollection<Motorcycle> Motorcycles { get; set; }
    }
}
