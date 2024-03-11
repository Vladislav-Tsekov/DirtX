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

        private static readonly Dictionary<OilType, string> CustomCategoryNames = new()
        {
            { OilType.Stroke4, "4T Motor Oils" },
            { OilType.Stroke2, "2T Motor Oils" },
            { OilType.Transmission, "Transmission Oils" },
            { OilType.Suspension, "Suspension Oils" },
            { OilType.Coolant, "Coolants" },
            { OilType.Lubricant, "Lubricants" }
        };

        private static string GetImageUrlForCategoryAsync(OilType type)
        {
            switch (type)
            {
                case OilType.Stroke4:
                    return "https://www.tdrmoto.com.au/cdn/shop/products/1_f77b9b2a-c02f-49c4-bab2-3ff908523beb.jpg?v=1559108074";
                case OilType.Stroke2:
                    return "https://mxchampusashop.com/cdn/shop/products/ktmfnt_943fac65-f56d-44e6-b044-97de45b5c6e5.jpg?v=1662520095";
                case OilType.Transmission:
                    return "https://s.alicdn.com/@sc04/kf/A1b9aa66dbfa04599865efe1b6a91097aS.jpg_300x300.jpg";
                case OilType.Suspension:
                    return "https://www.tracktrailpowersports.com/productimages/110895-Twin-Air-Dirt-Bike-Backfire-Replacement-Filter.png";
                case OilType.Coolant:
                    return "https://m.media-amazon.com/images/I/61DluB-9etL._AC_UF1000,1000_QL80_.jpg";
                case OilType.Lubricant:
                    return "https://m.media-amazon.com/images/I/61DluB-9etL._AC_UF1000,1000_QL80_.jpg";
                default:
                    return "https://placeholder.com/300";
            }
        }
    }
}
