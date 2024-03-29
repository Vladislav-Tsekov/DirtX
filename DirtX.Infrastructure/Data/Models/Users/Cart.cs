using DirtX.Infrastructure.Data.Models.Mappings;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DirtX.Infrastructure.Data.Models.Users
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(UserId))]
        public AppUser User { get; set; }
        public string UserId { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        public ICollection<CartProduct> CartProducts { get; set; }
    }
}
