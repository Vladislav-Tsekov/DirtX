using DirtX.Core.Models;
using DirtX.Infrastructure.Data.Models.Enums;
using DirtX.Infrastructure.Data.Models.Products;
using DirtX.Web.Data;
using DirtX.Web.Models;
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
            var oils = await context.Oils.Where(o => o.OilType == type).ToListAsync();

            var model = new ProductCategoryViewModel<Oil>
            {
                CategoryName = type.ToString(),
                Products = oils
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

            List<Oil> oils = await context.Oils.Where(p => p.BrandId == brand.Id).ToListAsync();

            ProductBrandViewModel<Oil> model = new()
            {
                Name = brand.Name,
                Description = brand.Description,
                ImageUrl = brand.ImageUrl,
                Products = oils
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            Oil oil = await context.Oils
                .Include(o => o.Brand)
                .Include(o => o.Specifications)
                .ThenInclude(op => op.Title)
                .FirstOrDefaultAsync(o => o.Id == id);

            if (oil == null)
            {
                return NotFound();
            }

            OilDetailsViewModel model = new()
            {
                Id = oil.Id,
                BrandName = oil.Brand.Name,
                PackageSize = oil.PackageSize,
                Title = oil.Title,
                Price = oil.Price,
                Description = oil.Description,
                IsAvailable = oil.IsAvailable,
                StockQuantity = oil.StockQuantity,
                ImageUrl = oil.ImageUrl,
                Specs = oil.Specifications
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
