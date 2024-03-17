using DirtX.Infrastructure.Data.Models;
using DirtX.Infrastructure.Data.Models.Enums;
using DirtX.Infrastructure.Data.Models.MotorcycleSpecs;
using DirtX.Infrastructure.Data.Models.Products;
using DirtX.Infrastructure.Data.Models.Products.Properties;
using DirtX.Web.Data;
using DirtX.Web.Models;
using DirtX.Web.Models.Part;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DirtX.Web.Controllers
{
    public class PartController : Controller
    {
        private readonly ApplicationDbContext context;

        public PartController(ApplicationDbContext _context)
        {
            context = _context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var categories = Enum.GetValues(typeof(PartType)).Cast<PartType>();

            var allParts = await context.Parts.ToListAsync();

            var distinctBrands = allParts
                .Select(p => p.BrandId)
                .Distinct()
                .ToList();

            var partsBrands = await context.ProductBrands
                .Where(brand => distinctBrands.Contains(brand.Id))
                .ToListAsync();

            var model = categories.Select(category =>
            {
                return new PartIndexViewModel
                {
                    CategoryName = category.ToString(),
                    ImageUrl = GetImageUrlForCategoryAsync(category),
                    Brands = partsBrands
                };
            }).ToList();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Category(PartType type)
        {
            var parts = await context.Parts.Where(p => p.Type == type).ToListAsync();

            var model = new PartCategoryViewModel
            {
                CategoryName = type.ToString(),
                Parts = parts
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Brand(string brandName)
        {
            ProductBrand brand = context.ProductBrands.FirstOrDefault(b => b.Name == brandName);

            if (brand is null)
            {
                return NotFound();
            }

            List<Part> brandParts = await context.Parts.Where(p => p.BrandId == brand.Id).ToListAsync();

            PartBrandViewModel model = new()
            {
                Name = brand.Name,
                Description = brand.Description,
                ImageUrl = brand.ImageUrl,
                Parts = brandParts
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            Part part = await context.Parts
                .Include(p => p.Brand)
                .Include(p => p.PartProperties)
                .ThenInclude(pp => pp.Specification)
                .ThenInclude(pp => pp.Title)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (part == null)
            {
                return NotFound();
            }

            List<PartSpecification> partSpecs = part.PartProperties
                .Select(ps => ps.Specification)
                .ToList();

            PartDetailsViewModel model = new()
            {
                Id = part.Id,
                Type = part.Type,
                BrandName = part.Brand.Name, 
                Title = part.Title,
                Price = part.Price,
                Description = part.Description,
                IsAvailable = part.IsAvailable,
                StockQuantity = part.StockQuantity,
                ImageUrl = part.ImageUrl,
                Specs = partSpecs
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> CompatibleParts(int makeId, int modelId, int displacementId, int yearId)
        {
            List<MotorcyclePart> compatibleParts = await context.MotorcyclesParts
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

        private static string GetImageUrlForCategoryAsync(PartType type)
        {
            switch (type)
            {
                case PartType.Engine:
                    return "https://i.ibb.co/jWNQWk2/engine.jpg";
                case PartType.Brake:
                    return "https://i.ibb.co/Lpnz4qR/Brakes.jpg";
                case PartType.Suspension:
                    return "https://i.ibb.co/CsC1t3w/Suspension.jpg";
                case PartType.Filter:
                    return "https://i.ibb.co/jh1vrCq/filters.png";
                case PartType.Drivetrain:
                    return "https://i.ibb.co/cCs6tQt/chain.jpg";
                default:
                    return "";
            }
        }
    }
}
