using DirtX.Core.Interfaces;
using DirtX.Infrastructure.Data.Models.Motorcycles;

namespace DirtX.Core.Services
{
    public class MotorcycleService : IMotorcycleService
    {
        public Task<List<UsedMotorcycle>> GetAllUsedMotorcyclesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<UsedMotorcycle> GetUsedMotorcycleAsync()
        {
            throw new NotImplementedException();
        }
    }
}
