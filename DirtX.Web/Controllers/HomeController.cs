using DirtX.Core.Interfaces;
using DirtX.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DirtX.Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IMotorcycleService motorcycleService;
        private readonly IProductService productService;

        public HomeController(IMotorcycleService _motorcycleService, IProductService _productService)
        {
            motorcycleService = _motorcycleService;
            productService = _productService;
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

                ViewBag.AllBrands = await productService.GetAllProductBrandsAsync();

                return View(makes);
            }
            catch (Exception)
            {
                return BadRequest();
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
            catch (Exception)
            {
                return BadRequest();
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
            catch (Exception)
            {
                return BadRequest();
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
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
