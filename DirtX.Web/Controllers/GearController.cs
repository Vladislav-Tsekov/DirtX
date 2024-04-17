using DirtX.Core.Enums;
using DirtX.Core.Interfaces;
using DirtX.Core.Models;
using DirtX.Infrastructure.Data.Models.Enums;
using DirtX.Infrastructure.Data.Models.Mappings;
using DirtX.Infrastructure.Data.Models.Products;
using Microsoft.AspNetCore.Mvc;

namespace DirtX.Web.Controllers
{
    public class GearController : BaseController
    {
        private readonly IProductService productService;

        public GearController(ILogger<GearController> _logger, IProductService _productService)
        {
            productService = _productService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                List<Product> gears = await productService.GetAllGearsAsync();
                List<ProductBrand> gearBrands = await productService.GetDistinctProductBrandsAsync(gears);
                List<ProductCategory> gearTypes = productService.GetProductCategories(gears);

                if (gears is null || gearBrands is null || gearTypes is null)
                {
                    return NotFound();
                }

                List<ProductIndexViewModel> model = gearTypes.Select(types =>
                {
                    return new ProductIndexViewModel
                    {
                        ProductCategory = types.ToString(),
                        Brands = gearBrands
                    };
                }).ToList();

                return View(model);
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(Error));
            }
        }

        [HttpGet]
        public async Task<IActionResult> Category(string category, ProductSorting sorting = ProductSorting.Name_Ascending)
        {
            try
            {
                if (Enum.TryParse(category, out ProductCategory currCategory))
                {
                    List<Product> gears = await productService.GetAllProductsByCategoryAsync(currCategory, sorting);

                    if (gears is null)
                    {
                        return NotFound();
                    }

                    ProductCategoryViewModel model = new()
                    {
                        ProductCategory = category.ToString(),
                        Products = gears
                    };

                    return View(model);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction(nameof(Error));
            }
        }

        [HttpGet]
        public async Task<IActionResult> Brand(string brandName)
        {
            try
            {
                ProductBrand brand = await productService.GetProductBrandAsync(brandName);

                if (brand is null)
                {
                    return NotFound();
                }

                List<Product> gears = await productService.GetProductsByBrandAsync(brand);

                if (gears is null)
                {
                    return NotFound();
                }

                ProductBrandViewModel model = new()
                {
                    Name = brand.Name,
                    Description = brand.Description,
                    ImageUrl = brand.ImageUrl,
                    Products = gears
                };

                return View(model);
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(Error));
            }
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                Product gear = await productService.GetProductAsync(id);

                if (gear is null)
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
                    StockQuantity = gear.StockQuantity,
                    Specs = gearSpecs
                };

                return View(model);
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(Error));
            }
        }
    }
}
