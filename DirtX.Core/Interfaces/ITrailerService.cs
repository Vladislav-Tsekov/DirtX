using DirtX.Infrastructure.Data.Models.Trailers;

namespace DirtX.Core.Interfaces
{
    public interface ITrailerService
    {
        Task<List<Trailer>> GetAllTrailersAsync();
        Task<Trailer> GetTrailerRentsById(int id);
    }
}
