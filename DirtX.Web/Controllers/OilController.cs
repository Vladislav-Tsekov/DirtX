using DirtX.Core.Models;
using DirtX.Infrastructure.Data.Models.Enums;
using DirtX.Infrastructure.Data.Models.Products;
using DirtX.Infrastructure.Data.Models.Products.Properties;
using DirtX.Web.Data;
using DirtX.Web.Models;
using DirtX.Web.Models.Part;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DirtX.Web.Controllers
{
    public class OilController : Controller
    {
        private readonly ApplicationDbContext context;

        public OilController(ApplicationDbContext _context)
        {
            context = _context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var categories = Enum.GetValues(typeof(OilType)).Cast<OilType>();

            var allOils = await context.Oils.ToListAsync();

            var distinctBrands = allOils
                .Select(p => p.BrandId)
                .Distinct()
                .ToList();

            var oildBrands = await context.ProductBrands
                .Where(brand => distinctBrands.Contains(brand.Id))
                .ToListAsync();

            var model = categories.Select(category =>
            {
                return new ProductIndexViewModel
                {
                    CategoryName = category.ToString(),
                    ImageUrl = GetImageUrlForCategoryAsync(category),
                    Brands = oildBrands
                };
            }).ToList();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Category(OilType type)
        {
            var oils = await context.Oils.Where(o => o.Type == type).ToListAsync();

            var model = new OilCategoryViewModel
            {
                CategoryName = type.ToString(),
                Oils = oils
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

            List<Oil> brandOils = await context.Oils.Where(p => p.BrandId == brand.Id).ToListAsync();

            OilBrandViewModel model = new()
            {
                Name = brand.Name,
                Description = brand.Description,
                ImageUrl = brand.ImageUrl,
                Oils = brandOils
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            Oil oil = await context.Oils
                .Include(o => o.Brand)
                .Include(o => o.OilProperties)
                .ThenInclude(op => op.Specification)
                .ThenInclude(op => op.Title)
                .FirstOrDefaultAsync(o => o.Id == id);

            if (oil == null)
            {
                return NotFound();
            }

            List<OilSpecification> oilSpecs = oil.OilProperties
                .Select(os => os.Specification)
                .ToList();

            OilDetailsViewModel model = new()
            {
                Id = oil.Id,
                Type = oil.Type,
                BrandName = oil.Brand.Name,
                Title = oil.Title,
                Price = oil.Price,
                Description = oil.Description,
                IsAvailable = oil.IsAvailable,
                StockQuantity = oil.StockQuantity,
                ImageUrl = oil.ImageUrl,
                Specs = oilSpecs
            };

            return View(model);
        }

        private static string GetImageUrlForCategoryAsync(OilType type)
        {
            switch (type)
            {
                case OilType.Four_Stroke:
                    return "https://i.ibb.co/56sGHHC/Oil-Motul-300-V-1-L.jpg";
                case OilType.Two_Stroke:
                    return "https://i.ibb.co/k58PBnC/Oil-Cross-Power-2-T.jpg";
                case OilType.Transmission:
                    return "https://i.ibb.co/zntBCFg/Oil-Transmission-Motul.jpg";
                case OilType.Suspension:
                    return "https://i.ibb.co/g9R6Ztv/Oil-Bel-Ray-Fork-5-W.jpg";
                case OilType.Coolant:
                    return "https://i.ibb.co/DRWKczb/Oil-Motul-Antifreeze.jpg";
                default:
                    return "";
            }
        }
    }
}
