using DirtX.Infrastructure.Data.Models.Enums;
using DirtX.Infrastructure.Data.Models.ProductModels;
using DirtX.Models.Gear;
using DirtX.Web.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DirtX.Controllers
{
    public class GearController : Controller
    {
        private readonly ApplicationDbContext context;

        public GearController(ApplicationDbContext _context)
        {
            context = _context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var categories = Enum.GetValues(typeof(GearType)).Cast<GearType>();

            var allGears = await context.Gears.ToListAsync();

            var distinctBrands = allGears
                .Select(g => g.BrandId)
                .Distinct()
                .ToList();

            var gearsBrands = await context.ProductBrands
                .Where(brand => distinctBrands.Contains(brand.Id))
                .ToListAsync();

            var model = categories.Select(category =>
            {
                return new GearIndexViewModel
                {
                    CategoryName = category.ToString(),
                    ImageUrl = GetImageUrlForCategoryAsync(category),
                    Brands = gearsBrands
                };
            }).ToList();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Category(GearType type)
        {
            var gears = await context.Gears.Where(o => o.Type == type).ToListAsync();

            var model = new GearCategoryViewModel
            {
                CategoryName = type.ToString(),
                Gears = gears
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

            List<Gear> brandGears = await context.Gears.Where(p => p.BrandId == brand.Id).ToListAsync();

            GearBrandViewModel model = new()
            {
                Name = brand.Name,
                Description = brand.Description,
                ImageUrl = brand.ImageUrl,
                Gears = brandGears
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var gear = await context.Gears
                .Include(o => o.Brand)
                .FirstOrDefaultAsync(o => o.Id == id);

            if (gear == null)
            {
                return NotFound();
            }

            GearDetailsViewModel model = new()
            {
                Id = gear.Id,
                Type = gear.Type,
                BrandName = gear.Brand.Name,
                Title = gear.Title,
                Price = gear.Price,
                Description = gear.Description,
                IsAvailable = gear.IsAvailable,
                StockQuantity = gear.StockQuantity,
                ImageUrl = gear.ImageUrl
            };

            return View(model);
        }

        private static string GetImageUrlForCategoryAsync(GearType type)
        {
            switch (type)
            {
                case GearType.Helmet:
                    return "https://i.ibb.co/pyjR9Dh/Gear-SM5-Helmet.jpg";
                case GearType.Protective_Gear:
                    return "https://i.ibb.co/3fW6GMp/Gear-Bionic-Action.jpg";
                case GearType.Outfit:
                    return "https://i.ibb.co/7QRGQvn/Gear-Thor-Outfit.jpg";
                case GearType.Boots:
                    return "https://i.ibb.co/pzGDVTv/Gear-Tech10-Boots.jpg";
                case GearType.Accessory:
                    return "https://i.ibb.co/Vm5NZBG/Gear-B20-Goggles.jpg";
                default:
                    return "";
            }
        }
    }
}
