using DirtX.Core.Interfaces;
using DirtX.Infrastructure.Data.Models.Trailers;

namespace DirtX.Core.Services
{
    public class TrailerService : ITrailerService
    {
        public Task<List<Trailer>> GetAllTrailersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Trailer> GetTrailerRentsById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
