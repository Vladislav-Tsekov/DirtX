using DirtX.Core.Interfaces;
using DirtX.Infrastructure.Data;
using DirtX.Infrastructure.Data.Models.Motorcycles;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DirtX.Core.Services
{
    public class MotorcycleService : IMotorcycleService
    {
        private readonly ApplicationDbContext context;

        public MotorcycleService(ApplicationDbContext _context)
        {
            context = _context;
        }

        public async Task<int> AddUsedMotorcycleAsync(UsedMotorcycle usedMotorcycle)
        {
            await context.UsedMotorcycles.AddAsync(usedMotorcycle);
            return await context.SaveChangesAsync();
        }

        public async Task<List<Motorcycle>> GetAllMotorcyclesAsync() 
        {
            return await context.Motorcycles
                .AsNoTracking()
                .Include(um => um.Make)
                .Include(um => um.Model)
                .Include(um => um.Year)
                .Include(um => um.Displacement)
                .ToListAsync();
        }

        public async Task<UsedMotorcycle> GetUsedMotorcycleAsync(int id)
        {
            return await context.UsedMotorcycles
                .AsNoTracking()
                .Include(um => um.Make)
                .Include(um => um.Model)
                .Include(um => um.Year)
                .Include(um => um.Displacement)
                .Where(um => um.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<List<UsedMotorcycle>> GetAllUsedMotorcyclesAsync()
        {
            return await context.UsedMotorcycles
                .AsNoTracking()
                .Include(um => um.Make)
                .Include(um => um.Model)
                .Include(um => um.Year)
                .Include(um => um.Displacement)
                .ToListAsync();
        }

        public async Task<List<SelectListItem>> GetMotorcycleMake()
        {
            return await context.Makes
                .AsNoTracking()
                .Select(m => new SelectListItem { Value = m.Id.ToString(), Text = m.Title })
                .ToListAsync();
        }

        public async Task<List<SelectListItem>> GetMotorcycleModel(int makeId)
        {
            return await context.Motorcycles
                .AsNoTracking()
                .Where(m => m.MakeId == makeId)
                .Select(m => new SelectListItem { Value = m.ModelId.ToString(), Text = m.Model.Title.ToString() })
                .Distinct()
                .ToListAsync();
        }

        public async Task<List<SelectListItem>> GetMotorcycleDisplacement(int makeId, int modelId)
        {
            return await context.Motorcycles
                .AsNoTracking()
                .Where(m => m.MakeId == makeId && m.ModelId == modelId)
                .Select(m => new SelectListItem { Value = m.DisplacementId.ToString(), Text = m.Displacement.Volume.ToString() })
                .Distinct()
                .ToListAsync();
        }

        public async Task<List<SelectListItem>> GetMotorcycleYears(int makeId, int modelId, int displacementId)
        {
            return await context.Motorcycles
                .AsNoTracking()
                .Where(m => m.MakeId == makeId && m.ModelId == modelId && m.DisplacementId == displacementId)
                .Select(m => new SelectListItem { Value = m.YearId.ToString(), Text = m.Year.ManufactureYear.ToString() })
                .Distinct()
                .ToListAsync();
        }
    }
}
