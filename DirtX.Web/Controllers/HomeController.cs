using DirtX.Models;
using DirtX.Web.Data;
using DirtX.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace DirtX.Web.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext context;

        public HomeController(ApplicationDbContext _context/*ILogger<HomeController> logger*/)
        {
            //_logger = logger;
            context = _context;
        }

        //TODO - MODELSTATE VALIDATION EVERYWHERE!
        //TODO - DROPDOWN JS - SELECT 2 LIBRARY

        public async Task<IActionResult> Index()
        {
            var viewModel = new MotoSelectionViewModel
            {
                Makes = await context.Makes.Select(m => new SelectListItem { Value = m.Id.ToString(), Text = m.Title }).ToListAsync(),
                Models = await context.Models.Select(m => new SelectListItem { Value = m.Id.ToString(), Text = m.Title }).ToListAsync(),
                Years = await context.Years.Select(m => new SelectListItem { Value = m.Id.ToString(), Text = m.ManufactureYear.ToString() }).ToListAsync()
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

            if (!ModelState.IsValid)
            {
                return Error();
            }

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

            if (!ModelState.IsValid)
            {
                return Error();
            }

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

            if (!ModelState.IsValid)
            {
                return Error();
            }

            return Json(years);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
