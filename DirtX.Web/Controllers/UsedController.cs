using DirtX.Core.Interfaces;
using DirtX.Core.Validation;
using DirtX.Infrastructure.Data;
using DirtX.Infrastructure.Data.Models.Enums;
using DirtX.Infrastructure.Data.Models.Motorcycles;
using DirtX.Web.Models.Home;
using DirtX.Web.Models.Used;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DirtX.Web.Controllers
{
    public class UsedController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        private readonly IMotorcycleService motorcycleService;

        public UsedController(ApplicationDbContext _context/*ILogger<HomeController> logger*/, IMotorcycleService _motorcycleService)
        {
            //_logger = logger;
            motorcycleService = _motorcycleService;
        }

        public async Task<IActionResult> Index()
        {
            List<UsedMotorcycle> usedMotorcycles = await motorcycleService.GetAllUsedMotorcyclesAsync();

            List<UsedMotoViewModel> models = usedMotorcycles.Select(m => new UsedMotoViewModel
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
        public async Task<IActionResult> Details(int id) 
        {
            //TODO - FIXE WHEN SERVICE IS IMPLEMENTED
            //TODO - LIMIT IMAGE SIZE WHEN OPENING THE VIEW
            //var motorcycleDetails = await usedService.GetMotorcycleDetailsById(id);

            UsedMotorcycle motoDetails = await motorcycleService.GetUsedMotorcycleAsync(id);

            if (motoDetails == null)
            {
                return NotFound(); 
            }

            if (!ModelState.IsValid)
            {
                return NotFound();
            }

            var viewModel = new UsedMotoViewModel
            {
                Make = motoDetails.Make.Title,
                Model = motoDetails.Model.Title,
                Displacement = motoDetails.Displacement.Volume,
                Year = motoDetails.Year.ManufactureYear,
                Image = motoDetails.Image,
                Province = motoDetails.Province.ToString(),
                Description = motoDetails.Description,
                Price = motoDetails.Price,
                Contact = motoDetails.Contact
            };

            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Sell()
        {
            var viewModel = new SellFormViewModel
            {
                Makes = await motorcycleService.GetMotorcycleMake()
            };

            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> GetModel(int makeId)
        {
            List<SelectListItem> models = await motorcycleService.GetMotorcycleModel(makeId);

            return Json(models);
        }

        [HttpGet]
        public async Task<IActionResult> GetDisplacement(int makeId, int modelId)
        {
            List<SelectListItem> displacements = await motorcycleService.GetMotorcycleDisplacement(makeId, modelId);

            return Json(displacements);
        }

        [HttpGet]
        public async Task<IActionResult> GetYear(int makeId, int modelId, int displacementId)
        {
            var years = await motorcycleService.GetMotorcycleYears(makeId, modelId, displacementId);

            return Json(years);
        }

        [HttpPost]
        public async Task<IActionResult> Sell(SellFormViewModel model)
        {
            if (model.ImageFile != null)
            {
                model.Image = FormFileConverter.ConvertToByteArray(model.ImageFile);
            }
            else
            {
                string currentDir = Directory.GetCurrentDirectory();
                string parentDir = Directory.GetParent(currentDir).FullName;
                //TODO-CHANGE DIRECTORY
                string defaultImgPath = Path.Combine(parentDir, @"DirtX.Infrastructure\Data\Seeders\Images\default-img.jpg");
                model.Image = System.IO.File.ReadAllBytes(defaultImgPath);
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var usedMotorcycle = new UsedMotorcycle
            {
                MakeId = model.SelectedMake,
                ModelId = model.SelectedModel,
                DisplacementId = model.SelectedDisplacement,
                YearId = model.SelectedYear,
                Price = model.Price,
                Image = model.Image,
                Province = (Province)model.Province,
                Description = model.Description,
                Contact = model.Contact
            };

            await motorcycleService.AddUsedMotorcycleAsync(usedMotorcycle);

            return RedirectToAction("Index", "Used");
        }
    }
}
