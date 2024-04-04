using DirtX.Core.Enums;
using DirtX.Core.Interfaces;
using DirtX.Core.Models;
using DirtX.Infrastructure.Data.Models.Enums;
using DirtX.Infrastructure.Data.Models.Mappings;
using DirtX.Infrastructure.Data.Models.Products;
using Microsoft.AspNetCore.Mvc;

namespace DirtX.Web.Controllers
{
    public class OilController : Controller
    {
        private readonly IProductService productService;

        public OilController(IProductService _oilService)
        {
            productService = _oilService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<Product> oils = await productService.GetAllOilsAsync();
            List<ProductBrand> oilBrands = await productService.GetDistinctProductBrandsAsync(oils);
            List<ProductCategory> oilTypes = productService.GetProductCategories(oils);

            //TODO - ERROR HANDLING, NULL HANDLING, AWAIT MULTIPLE ASYNC OPERATIONS BEFORE RETURNING MODEL?

            var model = oilTypes.Select(types =>
            {
                return new ProductIndexViewModel
                {
                    ProductCategory = types.ToString(),
                    Brands = oilBrands
                };
            }).ToList();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Category(string category, ProductSorting sorting = ProductSorting.Name_Ascending)
        {
            if (Enum.TryParse(category, out ProductCategory currCategory))
            {
                List<Product> oils = await productService.GetAllProductsByCategoryAsync(currCategory);

                switch (sorting)
                {
                    case ProductSorting.Name_Descending:
                        oils = oils.OrderByDescending(o => o.Title).ToList();
                        break;
                    case ProductSorting.Price_Ascending:
                        oils = oils.OrderBy(o => o.Price).ToList();
                        break;
                    case ProductSorting.Price_Descending:
                        oils = oils.OrderByDescending(o => o.Price).ToList();
                        break;
                    default:
                        break;
                }

                //TODO - ERROR HANDLING, NULL HANDLING, AWAIT MULTIPLE ASYNC OPERATIONS BEFORE RETURNING MODEL?

                var model = new ProductCategoryViewModel
                {
                    ProductCategory = category.ToString(),
                    Products = oils
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

            List<Product> oils = await productService.GetProductsByBrandAsync(brand);

            ProductBrandViewModel model = new()
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
