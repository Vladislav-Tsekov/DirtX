using DirtX.Core.Interfaces;
using DirtX.Core.Models;
using DirtX.Infrastructure.Data.Models;
using DirtX.Infrastructure.Data.Models.Mappings;
using DirtX.Infrastructure.Data.Models.Motorcycles;
using DirtX.Infrastructure.Data.Models.Products;
using DirtX.Web.Data;
using DirtX.Web.Models.Part;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DirtX.Web.Controllers
{
    public class PartController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IProductService productService;

        public PartController(ApplicationDbContext _context, IProductService _productService)
        {
            context = _context;
            productService = _productService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var categories = await context.Products.Where(p => p.Category.Name == "Part").ToListAsync();

            List<Product> parts = await productService.GetAllProductsAsync();

            List<ProductBrand> partsBrands = await productService.GetDistinctProductBrandsAsync();

            var model = categories.Select(category =>
            {
                return new ProductIndexViewModel
                {
                    CategoryName = category.ToString(),
                    Brands = partsBrands
                };
            }).ToList();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Category(string category)
        {
            List<Product> parts = await productService.GetAllProductsByCategoryAsync(category);

            var model = new ProductCategoryViewModel<Product>
            {
                CategoryName = category.ToString(),
                Products = parts
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

            var parts = await productService.GetProductsByBrandAsync(brand);

            var model = new ProductBrandViewModel<Product>
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
            List<MotorcycleProduct> compatibleParts = await context.MotorcyclesParts
                .Include(mp => mp.Motorcycle)
                .Include(mp => mp.Motorcycle.Make)
                .Include(mp => mp.Motorcycle.Model)
                .Include(mp => mp.Motorcycle.Displacement)
                .Include(mp => mp.Motorcycle.Year)
                .Include(mp => mp.Product.Brand)
                .Where(mp => mp.Motorcycle.MakeId == makeId &&
                             mp.Motorcycle.ModelId == modelId &&
                             mp.Motorcycle.DisplacementId == displacementId &&
                             mp.Motorcycle.YearId == yearId)
                .ToListAsync();

            Motorcycle motorcycle = compatibleParts.FirstOrDefault().Motorcycle;

            //TODO - ERROR HANDLING

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
