using DirtX.Core.Interfaces;
using DirtX.Core.Models;
using DirtX.Core.Services;
using DirtX.Infrastructure.Data.Models.Enums;
using DirtX.Infrastructure.Data.Models.Mappings;
using DirtX.Infrastructure.Data.Models.Products;
using DirtX.Web.Data;
using DirtX.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DirtX.Web.Controllers
{
    public class OilController : Controller
    {
        private readonly IProductService<Oil, OilType> oilService;

        public OilController(IProductService<Oil, OilType> _oilService)
        {
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

            ProductDetailsViewModel model = new()
            {
                Id = oil.Id,
                BrandName = oil.Brand.Name,
                Title = oil.Title,
                Price = oil.Price,
                Description = oil.Description,
                ImageUrl = oil.ImageUrl,
                Specs = oilSpecs
            };

            return View(model);
        }
    }
}
