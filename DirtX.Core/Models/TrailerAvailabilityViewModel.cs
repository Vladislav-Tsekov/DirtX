using DirtX.Infrastructure.Data.Models.Trailers;

namespace DirtX.Core.Models
{
    public class TrailerAvailabilityViewModel
    {
        public int TrailerId { get; set; }
        public string TrailerTitle { get; set; }
        public List<TrailerRent> Rents { get; set; }
    }
}
