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
            var viewModel = new MotorcycleViewModel
            {
                Makes = await context.Makes.Select(m => new SelectListItem { Value = m.Id.ToString(), Text = m.Title }).ToListAsync(),
                Models = await context.Models.Select(m => new SelectListItem { Value = m.Id.ToString(), Text = m.Title }).ToListAsync()
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

            var models = motorcycles.Select(m => new SelectListItem { Value = m.Id.ToString(), Text = m.Title });

            return Json(models);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
