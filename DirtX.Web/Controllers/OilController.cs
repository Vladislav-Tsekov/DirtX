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
    public class OilController : Controller
    {
        private readonly IProductService productService;
        private readonly ApplicationDbContext context;

        public OilController(IProductService _oilService, ApplicationDbContext context)
        {
            productService = _oilService;
            this.context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<Product> oils = await productService.GetAllPartsAsync();
            List<ProductBrand> oilBrands = await productService.GetDistinctProductBrandsAsync(oils);
            List<ProductType> oilTypes = productService.GetProductTypes(oils);

            var model = oilTypes.Select(types =>
            {
                return new ProductIndexViewModel
                {
                    CategoryName = types.ToString(),
                    Brands = oilBrands
                };
            }).ToList();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Category(string category)
        {
            List<Product> oils = await productService.GetAllProductsByCategoryAsync(category);

            var model = new ProductCategoryViewModel
            {
                CategoryName = category.ToString(),
                Products = oils
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

            var oils = await productService.GetProductsByBrandAsync(brand);

            var model = new ProductBrandViewModel
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
            Product oil = productService.GetProductAsync(id).Result;

            if (oil == null)
            {
                return NotFound();
            }

            List<ProductSpecification> oilSpecs = await productService.GetProductSpecificationsAsync(id);

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
