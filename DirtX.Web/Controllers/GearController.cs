using DirtX.Core.Enums;
using DirtX.Core.Interfaces;
using DirtX.Core.Models;
using DirtX.Infrastructure.Data.Models.Enums;
using DirtX.Infrastructure.Data.Models.Mappings;
using DirtX.Infrastructure.Data.Models.Products;
using Microsoft.AspNetCore.Mvc;

namespace DirtX.Web.Controllers
{
    public class GearController : Controller
    {
        private readonly IProductService productService;

        public GearController(IProductService _gearService)
        {
            productService = _gearService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<Product> gears = await productService.GetAllGearsAsync();
            List<ProductBrand> gearBrands = await productService.GetDistinctProductBrandsAsync(gears);
            List<ProductCategory> gearTypes = productService.GetProductCategories(gears);

            //TODO - ERROR HANDLING, NULL HANDLING, AWAIT MULTIPLE ASYNC OPERATIONS BEFORE RETURNING MODEL?

            var model = gearTypes.Select(types =>
            {
                return new ProductIndexViewModel
                {
                    ProductCategory = types.ToString(),
                    Brands = gearBrands
                };
            }).ToList();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Category(string category, ProductSorting sorting = ProductSorting.Name_Ascending)
        {
            if (Enum.TryParse(category, out ProductCategory currCategory))
            {
                List<Product> gears = await productService.GetAllProductsByCategoryAsync(currCategory);

                switch (sorting)
                {
                    case ProductSorting.Name_Descending:
                        gears = gears.OrderByDescending(o => o.Title).ToList();
                        break;
                    case ProductSorting.Price_Ascending:
                        gears = gears.OrderBy(o => o.Price).ToList();
                        break;
                    case ProductSorting.Price_Descending:
                        gears = gears.OrderByDescending(o => o.Price).ToList();
                        break;
                    default:
                        break;
                }

                //TODO - ERROR HANDLING, NULL HANDLING, AWAIT MULTIPLE ASYNC OPERATIONS BEFORE RETURNING MODEL?

                var model = new ProductCategoryViewModel
                {
                    ProductCategory = category.ToString(),
                    Products = gears
                };

                return View(model);
            }
            else
                return BadRequest();
        }

        [HttpGet]
        public async Task<IActionResult> Brand(string brandName)
        {
            ProductBrand brand = await productService.GetProductBrandAsync(brandName);

            if (brand is null)
                return NotFound();

            List<Product> gears = await productService.GetProductsByBrandAsync(brand);

            ProductBrandViewModel model = new()
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
