using DirtX.Infrastructure.Data.Models.Motorcycles;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static DirtX.Infrastructure.Shared.ValidationConstants;

namespace DirtX.Infrastructure.Data.Models.Users
{
    public class Garage
    {
        public Garage()
        {
            MotoCount = 0;
        }

        [Key]
        [ForeignKey(nameof(UserId))]
        [Comment("The ID of the user who owns the garage.")]
        public string UserId { get; set; }
        public AppUser User { get; set; }

        [Range(GarageMinCapacity, GarageMaxCapacity)]
        [Comment("The maximum number of motorcycles allowed in the garage.")]
        public int MotoCount { get; set; }

        [Comment("Motorcycles stored in the garage.")]
        public ICollection<Motorcycle> Motorcycles { get; set; } = new List<Motorcycle>();
    }
}
