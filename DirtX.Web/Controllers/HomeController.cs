using DirtX.Core.Interfaces;
using DirtX.Core.Models;
using DirtX.Web.Models.Home;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace DirtX.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;
        private readonly IMotorcycleService motorcycleService;

        public HomeController(ILogger<HomeController> _logger, IMotorcycleService _motorcycleService)
        {
            logger = _logger;
            motorcycleService = _motorcycleService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                MotoSelectionViewModel makes = new()
                {
                    Makes = await motorcycleService.GetMotorcycleMake()
                };

                return View(makes);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "AJAX OPERATION ERROR: An error occurred while fetching motorcycle makes. Debug the Home/Index action for more details.");
                return View("Error");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetModel(int makeId)
        {
            try
            {
                List<SelectListItem> models = await motorcycleService.GetMotorcycleModel(makeId);

                return Json(models);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "AJAX OPERATION ERROR: An error occurred while fetching motorcycle models. Debug the Home/GetModel action for more details.");
                return View("Error");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetDisplacement(int makeId, int modelId)
        {
            try
            {
                List<SelectListItem> displacements = await motorcycleService.GetMotorcycleDisplacement(makeId, modelId);

                return Json(displacements);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "AJAX OPERATION ERROR: An error occurred while fetching motorcycle displacements. Debug the Home/GetDisplacement action for more details.");
                return View("Error");
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetYear(int makeId, int modelId, int displacementId)
        {
            try
            {
                List<SelectListItem> years = await motorcycleService.GetMotorcycleYears(makeId, modelId, displacementId);

                return Json(years);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "AJAX OPERATION ERROR: An error occurred while fetching motorcycle years. Debug the Home/GetYear action for more details.");
                return View("Error");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
