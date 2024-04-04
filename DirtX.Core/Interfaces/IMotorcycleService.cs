using DirtX.Infrastructure.Data.Models.Motorcycles;

namespace DirtX.Core.Interfaces
{
    public interface IMotorcycleService
    {
        Task<UsedMotorcycle> GetUsedMotorcycleAsync();
        Task<List<UsedMotorcycle>> GetAllUsedMotorcyclesAsync();
    }
}
