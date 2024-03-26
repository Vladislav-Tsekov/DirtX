using DirtX.Core.Interfaces;
using DirtX.Core.Models;
using DirtX.Infrastructure.Data.Models;
using DirtX.Infrastructure.Data.Models.Enums;
using DirtX.Infrastructure.Data.Models.Motorcycles;
using DirtX.Infrastructure.Data.Models.Products;
using DirtX.Web.Data;
using DirtX.Web.Models.Part;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DirtX.Web.Controllers
{
    public class PartController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IProductService<Part, PartType> partService;

        public PartController(ApplicationDbContext _context, IProductService<Part, PartType> _partService)
        {
            context = _context;
            partService = _partService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<PartType> categories = Enum.GetValues(typeof(PartType)).Cast<PartType>();

            List<Part> parts = await partService.GetAllProductsAsync();

            List<ProductBrand> partsBrands = await partService.GetDistinctProductBrandsAsync();

            var model = categories.Select(category =>
            {
                return new ProductIndexViewModel
                {
                    CategoryName = category.ToString(),
                    Brands = partsBrands
                };
            }).ToList();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Category(PartType type)
        {
            List<Part> parts = await partService.GetAllProductsByTypeAsync(type);

            var model = new ProductCategoryViewModel<Part>
            {
                CategoryName = type.ToString(),
                Products = parts
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Brand(string brandName)
        {
            ProductBrand brand = await partService.GetProductBrandAsync(brandName);

            if (brand is null)
            {
                return NotFound();
            }

            var parts = await partService.GetProductsByBrandAsync(brand);

            var model = new ProductBrandViewModel<Part>
            {
                Name = brand.Name,
                Description = brand.Description,
                ImageUrl = brand.ImageUrl,
                Products = parts
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            Part part = partService.GetProductAsync(id).Result;

            if (part == null)
            {
                return NotFound();
            }

            List<ProductSpecification> partSpecs = await partService.GetProductSpecificationsAsync(id);

            ProductDetailsViewModel model = new()
            {
                Id = part.Id,
                BrandName = part.Brand.Name,
                Title = part.Title,
                Price = part.Price,
                Description = part.Description,
                ImageUrl = part.ImageUrl,
                Specs = partSpecs
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> CompatibleParts(int makeId, int modelId, int displacementId, int yearId)
        {
            List<MotorcycleProduct> compatibleParts = await context.MotorcyclesParts
                .Include(mp => mp.Motorcycle)
                .Include(mp => mp.Motorcycle.Make)
                .Include(mp => mp.Motorcycle.Model)
                .Include(mp => mp.Motorcycle.Displacement)
                .Include(mp => mp.Motorcycle.Year)
                .Include(mp => mp.Part.Brand)
                .Where(mp => mp.Motorcycle.MakeId == makeId &&
                             mp.Motorcycle.ModelId == modelId &&
                             mp.Motorcycle.DisplacementId == displacementId &&
                             mp.Motorcycle.YearId == yearId)
                .ToListAsync();

            Motorcycle motorcycle = compatibleParts.FirstOrDefault().Motorcycle;

            //TODO - ERROR HANDLING

            CompatiblePartsViewModel model = new()
            {
                Make = motorcycle.Make.Title,
                Model = motorcycle.Model.Title,
                Displacement = motorcycle.Displacement.Volume.ToString(),
                Year = motorcycle.Year.ManufactureYear.ToString(),
                Parts = compatibleParts.Select(cp => cp.Part).ToList(),
            };

            return View(model);
        }
    }
}
