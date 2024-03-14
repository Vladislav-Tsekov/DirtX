using DirtX.Web.Data;
using DirtX.Web.Models.Used;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DirtX.Web.Controllers
{
    public class UsedController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext context;

        public UsedController(ApplicationDbContext _context/*ILogger<HomeController> logger*/)
        {
            //_logger = logger;
            context = _context;
        }

        public async Task<IActionResult> Index()
        {
            var usedMotorcycles = await context.UsedMotorcycles
                .Include(um => um.Make)
                .Include(um => um.Model)
                .Include(um => um.Year)
                .Include(um => um.Displacement)
                .ToListAsync();

            List<UsedIndexViewModel> models = usedMotorcycles.Select(m => new UsedIndexViewModel
            {
                Id = m.Id,
                Make = m.Make.Title,
                Model = m.Model.Title,
                Displacement = m.Displacement.Volume,
                Year = m.Year.ManufactureYear,
                Image = m.Image,
                Province = m.Province.ToString(),
                Description = m.Description,
                Price = m.Price,
                Contact = m.Contact
            }).ToList();

            return View(models);
        }

        public IActionResult Sell()
        {
            return View();
        }
    }
}
