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
    public class PartController : Controller
    {
        private readonly IProductService productService;

        public PartController(IProductService _productService)
        {
            productService = _productService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<Product> parts = await productService.GetAllPartsAsync();
            List<ProductBrand> partBrands = await productService.GetDistinctProductBrandsAsync(parts);
            List<ProductCategory> partTypes = productService.GetProductCategories(parts);

            //TODO - ERROR HANDLING, NULL HANDLING, AWAIT MULTIPLE ASYNC OPERATIONS BEFORE RETURNING MODEL?

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

        [HttpGet]
        public async Task<IActionResult> Category(string category, ProductSorting sorting = ProductSorting.Name_Ascending)
        {
            if (Enum.TryParse(category, out ProductCategory currCategory))
            {
                List<Product> parts = await productService.GetAllProductsByCategoryAsync(currCategory);

                switch (sorting)
                {
                    case ProductSorting.Name_Descending:
                        parts = parts.OrderByDescending(o => o.Title).ToList();
                        break;
                    case ProductSorting.Price_Ascending:
                        parts = parts.OrderBy(o => o.Price).ToList();
                        break;
                    case ProductSorting.Price_Descending:
                        parts = parts.OrderByDescending(o => o.Price).ToList();
                        break;
                    default:
                        break;
                }

                //TODO - ERROR HANDLING, NULL HANDLING, AWAIT MULTIPLE ASYNC OPERATIONS BEFORE RETURNING MODEL?

                ProductCategoryViewModel model = new()
                {
                    ProductCategory = category.ToString(),
                    Products = parts
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

            List<Product> parts = await productService.GetProductsByBrandAsync(brand);

            ProductBrandViewModel model = new()
            {
                Name = brand.Name,
                Description = brand.Description,
                ImageUrl = brand.ImageUrl,
                Products = parts
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            Product part = productService.GetProductAsync(id).Result;

            if (part == null)
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
                Specs = partSpecs
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> CompatibleParts(int makeId, int modelId, int displacementId, int yearId)
        {
            List<MotorcycleProduct> compatibleParts = await productService.GetCompatiblePartsAsync(makeId, modelId, displacementId, yearId);

            if (compatibleParts == null || !compatibleParts.Any())
                return NotFound();

            Motorcycle motorcycle = compatibleParts.FirstOrDefault().Motorcycle;

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
    }
}
