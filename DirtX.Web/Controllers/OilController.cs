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
        private readonly ILogger<OilController> logger;
        private readonly IProductService productService;

        public OilController(ILogger<OilController> _logger, IProductService _productService)
        {
            logger = _logger;
            productService = _productService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                List<Product> oils = await productService.GetAllOilsAsync();
                List<ProductBrand> oilBrands = await productService.GetDistinctProductBrandsAsync(oils);
                List<ProductCategory> oilTypes = productService.GetProductCategories(oils);

                if (oils is null || oilBrands is null || oilTypes is null)
                {
                    logger.LogError("An error occurred in the Oil/Index action. At least one out of three collections is null.");
                    return NotFound();
                }

                List<ProductIndexViewModel> model = oilTypes.Select(types =>
                {
                    return new ProductIndexViewModel
                    {
                        ProductCategory = types.ToString(),
                        Brands = oilBrands
                    };
                }).ToList();

                return View(model);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred in the Oil/Index action. Debug for more information.");
                return View("Error");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Category(string category, ProductSorting sorting = ProductSorting.Name_Ascending)
        {
            try
            {
                if (Enum.TryParse(category, out ProductCategory currCategory))
                {
                    List<Product> oils = await productService.GetAllProductsByCategoryAsync(currCategory, sorting);

                    if (oils is null)
                    {
                        logger.LogError($"An error occurred in the Oil/Category action. '{currCategory}' category may not exists.");
                        return NotFound();
                    }

                    ProductCategoryViewModel model = new()
                    {
                        ProductCategory = category.ToString(),
                        Products = oils
                    };

                    return View(model);
                }
                else
                {
                    logger.LogError($"Enum parsing failed in the Oil/Category action, while trying to parse {category}.");
                    return View("Error");
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred in the Oil/Category action. Debug for more information.");
                return View("Error");
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
                    logger.LogError($"An error occurred in the Oil/Brand action. Brand with name '{brandName}' could not be found.");
                    return NotFound();
                }

                List<Product> oils = await productService.GetProductsByBrandAsync(brand);

                if (oils is null)
                {
                    logger.LogError($"An error occurred in the Oil/Brand action. Oils collection for '{brandName}' is null.");
                    return NotFound();
                }

                ProductBrandViewModel model = new()
                {
                    Name = brand.Name,
                    Description = brand.Description,
                    ImageUrl = brand.ImageUrl,
                    Products = oils
                };

                return View(model);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred in the Oil/Brand action. Debug for more information.");
                return View("Error");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                Product oil = await productService.GetProductAsync(id);

                if (oil is null)
                {
                    logger.LogError($"An error occurred in the Oil/Details action. Product with ID '{id}' could not be found.");
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
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred in the Oil/Details action. Debug for more information.");
                return View("Error");
            }
        }
    }
}
