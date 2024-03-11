using DirtX.Infrastructure.Data.Models.Enums;
using DirtX.Infrastructure.Data.Models.ProductModels;
using DirtX.Models;
using DirtX.Web.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DirtX.Controllers
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
                var customName = CustomCategoryNames.ContainsKey(category) ? CustomCategoryNames[category] : category.ToString();

                return new OilIndexViewModel
                {
                    CategoryName = customName,
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

            var model = new CategoryViewModel
            {
                CategoryName = type.ToString(),
                Oils = oils
            };

            return View(model);
        }

        private static readonly Dictionary<OilType, string> CustomCategoryNames = new()
        {
            { OilType.Stroke4, "4T Motor Oils" },
            { OilType.Stroke2, "2T Motor Oils" },
            { OilType.Transmission, "Transmission Oils" },
            { OilType.Suspension, "Suspension Oils" },
            { OilType.Coolant, "Coolants" }
        };

        private static string GetImageUrlForCategoryAsync(OilType type)
        {
            switch (type)
            {
                case OilType.Stroke4:
                    return "https://i.ibb.co/56sGHHC/Oil-Motul-300-V-1-L.jpg";
                case OilType.Stroke2:
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
