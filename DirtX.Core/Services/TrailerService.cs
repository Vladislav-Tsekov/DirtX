using DirtX.Core.Interfaces;
using DirtX.Infrastructure.Data;
using DirtX.Infrastructure.Data.Models.Trailers;

namespace DirtX.Core.Services
{
    public class TrailerService : ITrailerService
    {
        private readonly ApplicationDbContext context;

        public TrailerService(ApplicationDbContext _context)
        {
            context = _context;
        }

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
