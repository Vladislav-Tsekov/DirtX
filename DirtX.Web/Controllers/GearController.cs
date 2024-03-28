using DirtX.Core.Interfaces;
using DirtX.Core.Models;
using DirtX.Infrastructure.Data.Models.Enums;
using DirtX.Infrastructure.Data.Models.Mappings;
using DirtX.Infrastructure.Data.Models.Products;
using DirtX.Web.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DirtX.Web.Controllers
{
    public class GearController : Controller
    {
        private readonly IProductService productService;
        private readonly ApplicationDbContext applicationDbContext;

        public GearController(IProductService _gearService, ApplicationDbContext applicationDbContext)
        {
            productService = _gearService;
            this.applicationDbContext = applicationDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<Product> gears = await productService.GetAllGearsAsync();
            List<ProductBrand> gearBrands = await productService.GetDistinctProductBrandsAsync(gears);
            List<ProductCategory> gearTypes = productService.GetProductCategories(gears);

            var model = gearTypes.Select(types =>
            {
                return new ProductIndexViewModel
                {
                    ProductType = types.ToString(),
                    Brands = gearBrands
                };
            }).ToList();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Category(string category)
        {
            List<Product> gears = await productService.GetAllProductsByCategoryAsync(category);

            var model = new ProductCategoryViewModel
            {
                CategoryName = category,
                Products = gears
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Brand(string brandName)
        {
            ProductBrand brand = await productService.GetProductBrandAsync(brandName);

            if (brand is null)
            {
                return NotFound();
            }

            var gears = await productService.GetProductsByBrandAsync(brand);

            var model = new ProductBrandViewModel
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
            Product gear = productService.GetProductAsync(id).Result;

            if (gear == null)
            {
                return NotFound();
            }

            List<ProductSpecification> gearSpecs = await productService.GetProductSpecificationsAsync(id);

            ProductDetailsViewModel model = new()
            {
                Id = gear.Id,
                BrandName = gear.Brand.Name,
                Title = gear.Title,
                Price = gear.Price,
                Description = gear.Description,
                ImageUrl = gear.ImageUrl,
                Specs = gearSpecs
            };

            return View(model);
        }
    }
}
