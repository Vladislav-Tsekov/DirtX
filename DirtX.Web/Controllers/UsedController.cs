using DirtX.Core.Interfaces;
using DirtX.Core.Models;
using DirtX.Core.Validation;
using DirtX.Infrastructure.Data.Models.Enums;
using DirtX.Infrastructure.Data.Models.Motorcycles;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DirtX.Web.Controllers
{
    public class UsedController : BaseController
    {
        private readonly IMotorcycleService motorcycleService;

        public UsedController(IMotorcycleService _motorcycleService)
        {
            motorcycleService = _motorcycleService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                List<UsedMotorcycle> usedMotorcycles = await motorcycleService.GetAllUsedMotorcyclesAsync();

                if (usedMotorcycles is null)
                {
                    return NotFound();
                }

                List<UsedMotoViewModel> model = usedMotorcycles.Select(m => new UsedMotoViewModel
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

                return View(model);
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(Error));
            }
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                UsedMotorcycle motoDetails = await motorcycleService.GetUsedMotorcycleAsync(id);

                if (motoDetails is null)
                {
                    return NotFound();
                }

                UsedMotoViewModel model = new()
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

                return View(model);
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(Error));
            }
        }

        [HttpGet]
        public async Task<IActionResult> Sell()
        {
            try
            {
                SellFormViewModel makes = new()
                {
                    Makes = await motorcycleService.GetMotorcycleMake()
                };

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

        [HttpPost]
        public async Task<IActionResult> Sell(SellFormViewModel model)
        {
            if (model.ImageFile is not null)
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

            UsedMotorcycle usedMotorcycle = new()
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

            return RedirectToAction(nameof(Index), "Used");
        }
    }
}
