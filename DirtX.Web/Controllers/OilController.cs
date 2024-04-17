using DirtX.Core.Enums;
using DirtX.Core.Interfaces;
using DirtX.Core.Models;
using DirtX.Infrastructure.Data.Models.Enums;
using DirtX.Infrastructure.Data.Models.Mappings;
using DirtX.Infrastructure.Data.Models.Products;
using Microsoft.AspNetCore.Mvc;

namespace DirtX.Web.Controllers
{
    public class OilController : BaseController
    {
        private readonly IProductService productService;

        public OilController(IProductService _productService)
        {
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
                    List<Product> oils = await productService.GetAllProductsByCategoryAsync(currCategory, sorting);

                    if (oils is null)
                    {
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
                    return BadRequest();
                }
            }
            catch (Exception)
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

                List<Product> oils = await productService.GetProductsByBrandAsync(brand);

                if (oils is null)
                {
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
                Product oil = await productService.GetProductAsync(id);

                if (oil is null)
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
                    StockQuantity = oil.StockQuantity,
                    Specs = oilSpecs
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
