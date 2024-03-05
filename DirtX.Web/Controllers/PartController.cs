using DirtX.Infrastructure.Data.Models.Enums;
using DirtX.Models;
using DirtX.Web.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DirtX.Controllers
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
        public async Task<IActionResult> Details(int id)
        {
            var part = await context.Parts
                .Include(p => p.Brand)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (part == null)
            {
                return NotFound();
            }

            var partViewModel = new PartDetailsViewModel
            {
                Id = part.Id,
                Type = part.Type,
                BrandName = part.Brand.Name, 
                Title = part.Title,
                Price = part.Price,
                Description = part.Description,
                IsAvailable = part.IsAvailable,
                StockQuantity = part.StockQuantity
            };

            return View(partViewModel);
        }

        private static string GetImageUrlForCategoryAsync(PartType type)
        {
            switch (type)
            {
                case PartType.Engine:
                    return "https://www.tdrmoto.com.au/cdn/shop/products/1_f77b9b2a-c02f-49c4-bab2-3ff908523beb.jpg?v=1559108074";
                case PartType.Brake:
                    return "https://mxchampusashop.com/cdn/shop/products/ktmfnt_943fac65-f56d-44e6-b044-97de45b5c6e5.jpg?v=1662520095";
                case PartType.Suspension:
                    return "https://s.alicdn.com/@sc04/kf/A1b9aa66dbfa04599865efe1b6a91097aS.jpg_300x300.jpg";
                case PartType.Filter:
                    return "https://www.tracktrailpowersports.com/productimages/110895-Twin-Air-Dirt-Bike-Backfire-Replacement-Filter.png";
                case PartType.Drivetrain:
                    return "https://m.media-amazon.com/images/I/61DluB-9etL._AC_UF1000,1000_QL80_.jpg";
                default:
                    return "https://placeholder.com/300";
            }
        }
    }
}
