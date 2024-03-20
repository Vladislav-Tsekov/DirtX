using DirtX.Core.Interfaces;
using DirtX.Core.Models;
using DirtX.Core.Services;
using DirtX.Infrastructure.Data.Models;
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
        private readonly IProductService<Oil, OilType> oilService;

        public OilController(ApplicationDbContext _context, IProductService<Oil, OilType> _oilService)
        {
            context = _context;
            oilService = _oilService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<OilType> categories = Enum.GetValues(typeof(OilType)).Cast<OilType>();

            List<Oil> oils = await oilService.GetAllProductsAsync();

            List<ProductBrand> oilsBrands = await oilService.GetDistinctProductBrandsAsync();

            var model = categories.Select(category =>
            {
                return new ProductIndexViewModel
                {
                    CategoryName = category.ToString(),
                    ImageUrl = GetImageUrlForCategoryAsync(category),
                    Brands = oilsBrands
                };
            }).ToList();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Category(OilType type)
        {
            List<Oil> oils = await oilService.GetAllProductsByTypeAsync(type);

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
            ProductBrand brand = await oilService.GetProductBrandAsync(brandName);

            if (brand is null)
            {
                return NotFound();
            }

            var oils = await oilService.GetProductsByBrandAsync(brand);

            var model = new ProductBrandViewModel<Oil>
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
            Oil oil = oilService.GetProductAsync(id).Result;

            if (oil == null)
            {
                return NotFound();
            }

            List<ProductSpecification> oilSpecs = await oilService.GetProductSpecificationsAsync(id);

            PartDetailsViewModel model = new()
            {
                Id = oil.Id,
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
