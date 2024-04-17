using DirtX.Core.Enums;
using DirtX.Core.Interfaces;
using DirtX.Core.Models;
using DirtX.Infrastructure.Data.Models;
using DirtX.Infrastructure.Data.Models.Enums;
using DirtX.Infrastructure.Data.Models.Mappings;
using DirtX.Infrastructure.Data.Models.Motorcycles;
using DirtX.Infrastructure.Data.Models.Products;
using Microsoft.AspNetCore.Mvc;

namespace DirtX.Web.Controllers
{
    public class PartController : BaseController
    {
        private readonly IProductService productService;

        public PartController(IProductService _productService)
        {
            productService = _productService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                List<Product> parts = await productService.GetAllPartsAsync();
                List<ProductBrand> partBrands = await productService.GetDistinctProductBrandsAsync(parts);
                List<ProductCategory> partTypes = productService.GetProductCategories(parts);

                if (parts is null || partBrands is null || partTypes is null)
                {
                    return NotFound();
                }

                List<ProductIndexViewModel> model = partTypes.Select(types =>
                {
                    return new ProductIndexViewModel
                    {
                        ProductCategory = types.ToString(),
                        Brands = partBrands
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
                    List<Product> parts = await productService.GetAllProductsByCategoryAsync(currCategory, sorting);

                    if (parts is null)
                    {
                        return NotFound();
                    }

                    ProductCategoryViewModel model = new()
                    {
                        ProductCategory = category.ToString(),
                        Products = parts
                    };

                    return View(model);
                }
                else
                {
                    return RedirectToAction(nameof(Error));
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

                List<Product> parts = await productService.GetProductsByBrandAsync(brand);

                if (parts is null)
                {
                    return NotFound();
                }

                ProductBrandViewModel model = new()
                {
                    Name = brand.Name,
                    Description = brand.Description,
                    ImageUrl = brand.ImageUrl,
                    Products = parts
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
                Product part = await productService.GetProductAsync(id);

                if (part is null)
                {
                    return NotFound();
                }

                List<ProductSpecification> partSpecs = await productService.GetProductSpecificationsAsync(id);

                ProductDetailsViewModel model = new()
                {
                    Id = part.Id,
                    BrandName = part.Brand.Name,
                    Title = part.Title,
                    Price = part.Price,
                    Description = part.Description,
                    ImageUrl = part.ImageUrl,
                    StockQuantity = part.StockQuantity,
                    Specs = partSpecs
                };

                return View(model);
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(Error));
            }
        }

        [HttpGet]
        public async Task<IActionResult> CompatibleParts(int makeId, int modelId, int displacementId, int yearId)
        {
            try
            {
                List<MotorcycleProduct> compatibleParts = await productService.GetCompatiblePartsAsync(makeId, modelId, displacementId, yearId);

                if (compatibleParts is null)
                {
                    return BadRequest();
                }

                Motorcycle motorcycle = compatibleParts.FirstOrDefault().Motorcycle;

                if (motorcycle is null)
                {
                    return NotFound();
                }

                CompatiblePartsViewModel model = new()
                {
                    Make = motorcycle.Make.Title,
                    Model = motorcycle.Model.Title,
                    Displacement = motorcycle.Displacement.Volume.ToString(),
                    Year = motorcycle.Year.ManufactureYear.ToString(),
                    Parts = compatibleParts.Select(cp => cp.Product).ToList(),
                };

                return View(model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
