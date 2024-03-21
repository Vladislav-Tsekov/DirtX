using DirtX.Infrastructure.Data.Models.Enums;
using DirtX.Web.Data;
using DirtX.Web.Models.Home;
using DirtX.Web.Models.Used;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        [HttpGet]
        public async Task<IActionResult> Sell()
        {
            var viewModel = new SellFormViewModel
            {
                Makes = await context.Makes.Select(m => new SelectListItem { Value = m.Id.ToString(), Text = m.Title }).ToListAsync(),
                Models = await context.Models.Select(m => new SelectListItem { Value = m.Id.ToString(), Text = m.Title }).ToListAsync(),
                Years = await context.Years.Select(m => new SelectListItem { Value = m.Id.ToString(), Text = m.ManufactureYear.ToString() }).ToListAsync(),
                //Provinces = provinces
            };

            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> GetMotorcycle(int make)
        {
            var motorcycles = await context.Motorcycles
                .Include(m => m.Model)
                .Where(m => m.MakeId == make)
                .Select(m => m.Model)
                .Distinct()
                .ToListAsync();

            var makesAndModels = motorcycles.Select(m => new SelectListItem { Value = m.Id.ToString(), Text = m.Title });

            return Json(makesAndModels);
        }

        [HttpGet]
        public async Task<IActionResult> GetDisplacement(int make, int model)
        {
            var displacements = await context.Motorcycles
                .Where(m => m.MakeId == make && m.ModelId == model)
                .Select(m => new SelectListItem { Value = m.DisplacementId.ToString(), Text = m.Displacement.Volume.ToString() })
                .Distinct()
                .ToListAsync();

            return Json(displacements);
        }

        [HttpGet]
        public async Task<IActionResult> GetYear(int make, int model, int displacement)
        {
            var years = await context.Motorcycles
                .Where(m => m.MakeId == make && m.ModelId == model && m.DisplacementId == displacement)
                .Select(m => new SelectListItem { Value = m.YearId.ToString(), Text = m.Year.ManufactureYear.ToString() })
                .Distinct()
                .ToListAsync();

            return Json(years);
        }
    }
}
