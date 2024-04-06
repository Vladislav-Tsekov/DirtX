using DirtX.Core.Interfaces;
using DirtX.Core.Models;
using DirtX.Infrastructure.Data;
using DirtX.Web.Models.Home;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DirtX.Web.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        private readonly IMotorcycleService motorcycleService;

        public HomeController(ApplicationDbContext _context/*ILogger<HomeController> logger*/, IMotorcycleService _motorcycleService)
        {
            //_logger = logger;
            motorcycleService = _motorcycleService;
        }

        //TODO - MODELSTATE VALIDATION EVERYWHERE!

        public async Task<IActionResult> Index()
        {
            var makes = new MotoSelectionViewModel
            {
                Makes = await motorcycleService.GetMotorcycleMake()
            };

            return View(makes);
        }

        [HttpGet]
        public async Task<IActionResult> GetModel(int makeId)
        {
            var models = await motorcycleService.GetMotorcycleModel(makeId);

            if (!ModelState.IsValid)
            {
                return Error();
            }

            return Json(models);
        }

        [HttpGet]
        public async Task<IActionResult> GetDisplacement(int makeId, int modelId)
        {
            var displacements = await motorcycleService.GetMotorcycleDisplacement(makeId, modelId);

            if (!ModelState.IsValid)
            {
                return Error();
            }

            return Json(displacements);
        }

        [HttpGet]
        public async Task<IActionResult> GetYear(int makeId, int modelId, int displacementId)
        {
            var years = await motorcycleService.GetMotorcycleYears(makeId, modelId, displacementId);

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
