using DirtX.Infrastructure.Data.Models.Motorcycles;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DirtX.Core.Interfaces
{
    public interface IMotorcycleService
    {
        Task<List<Motorcycle>> GetAllMotorcyclesAsync();
        Task<int> AddUsedMotorcycleAsync(UsedMotorcycle usedMotorcycle);
        Task<UsedMotorcycle> GetUsedMotorcycleAsync(int id);
        Task<List<UsedMotorcycle>> GetAllUsedMotorcyclesAsync();
        Task<List<SelectListItem>> GetMotorcycleMake();
        Task<List<SelectListItem>> GetMotorcycleModel(int makeId);
        Task<List<SelectListItem>> GetMotorcycleDisplacement(int makeId, int modelId);
        Task<List<SelectListItem>> GetMotorcycleYears(int makeId, int modelId, int displacementId);
    }
}
