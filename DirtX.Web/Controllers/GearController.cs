using DirtX.Core.Interfaces;
using DirtX.Core.Models;
using DirtX.Infrastructure.Data.Models;
using DirtX.Infrastructure.Data.Models.Enums;
using DirtX.Infrastructure.Data.Models.Products;
using DirtX.Web.Data;
using DirtX.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace DirtX.Web.Controllers
{
    public class GearController : Controller
    {
        private readonly IProductService<Gear, GearType> gearService;

        public GearController(IProductService<Gear, GearType> _gearService)
        {
            gearService = _gearService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<GearType> categories = Enum.GetValues(typeof(GearType)).Cast<GearType>();

            List<Gear> gears = await gearService.GetAllProductsAsync();

            List<ProductBrand> gearsBrands = await gearService.GetDistinctProductBrandsAsync();

            var model = categories.Select(category =>
            {
                return new ProductIndexViewModel
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
            List<Gear> gears = await gearService.GetAllProductsByTypeAsync(type);

            var model = new ProductCategoryViewModel<Gear>
            {
                CategoryName = type.ToString(),
                Products = gears
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Brand(string brandName)
        {
            ProductBrand brand = await gearService.GetProductBrandAsync(brandName);

            if (brand is null)
            {
                return NotFound();
            }

            var gears = await gearService.GetProductsByBrandAsync(brand);

            var model = new ProductBrandViewModel<Gear>
            {
                Name = brand.Name,
                Description = brand.Description,
                ImageUrl = brand.ImageUrl,
                Products = gears
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            Gear gear = gearService.GetProductAsync(id).Result;

            if (gear == null)
            {
                return NotFound();
            }

            List<ProductSpecification> gearSpecs = await gearService.GetProductSpecificationsAsync(id);

            PartDetailsViewModel model = new()
            {
                Id = gear.Id,
                BrandName = gear.Brand.Name,
                Title = gear.Title,
                Price = gear.Price,
                Description = gear.Description,
                IsAvailable = gear.IsAvailable,
                StockQuantity = gear.StockQuantity,
                ImageUrl = gear.ImageUrl,
                Specs = gearSpecs
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
