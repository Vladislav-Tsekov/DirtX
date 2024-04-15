﻿using DirtX.Core.Interfaces;
using DirtX.Core.Models.Admin;
using DirtX.Infrastructure.Data.Models.Motorcycles;
using DirtX.Infrastructure.Data.Models.Products;
using Microsoft.AspNetCore.Mvc;

namespace DirtX.Web.Areas.Admin.Controllers
{
    public class ProductController : BaseController
    {
        //TODO - ADD LOGGER
        private readonly IProductService productService;
        private readonly IMotorcycleService motorcycleService;

        public ProductController(IProductService _productService, IMotorcycleService _motorcycleService)
        {
            productService = _productService;
            motorcycleService = _motorcycleService;
        }

        [HttpGet]
        public IActionResult AddBrand()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddBrand(BrandFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData["ErrorMessage"] = "Invalid model.";
                return View(model);
            }

            try
            {
                productService.AddProductBrandAsync(model);

                return RedirectToAction("Index", "Admin");
            }
            catch (Exception)
            {
                TempData["ErrorMessage"] = "An unexpected error occurred. Please try again.";
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult AddSpecification()
        {
            var viewModel = new SpecificationFormViewModel();

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult AddSpecification(SpecificationFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            productService.AddSpecificationAsync(model);

            return RedirectToAction("Index", "Admin");
        }

        [HttpGet]
        public async Task<IActionResult> AddProduct()
        {
            try
            {
                ProductFormViewModel model = new()
                {
                    Brands = await productService.GetAllProductBrandsAsync(),
                    Types = await productService.GetAllProductTypesAsync()
                };
                return View(model);
            }
            catch (Exception)
            {
                return GeneralErrorMessage();
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData["ErrorMessage"] = "An unexpected error occurred! Please, try again.";
                return View(model);
            }

            try
            {
                await productService.AddProductAsync(model);
                return RedirectToAction("Index", "Admin");
            }
            catch (Exception)
            {
                TempData["ErrorMessage"] = "An unexpected error occurred! Please, try again.";
                return View(model);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var currProduct = await productService.GetProductEditFormAsync(id);
                return View(currProduct);
            }
            catch (Exception)
            {
                return GeneralErrorMessage();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, ProductFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData["ErrorMessage"] = "An unexpected error occurred! Please, try again.";
                return View(model);
            }

            try
            {
                await productService.EditProductAsync(id, model);
            }
            catch (Exception)
            {
                return GeneralErrorMessage();
            }

            return RedirectToAction("Products", "Admin");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await productService.DeleteProductAsync(id);

                return RedirectToAction("Products", "Admin");
            }
            catch (Exception)
            {
                return GeneralErrorMessage();
            }
        }

        [HttpGet]
        public async Task<IActionResult> LinkWithMotorcycle(int productId)
        {
            try
            {
                List<Motorcycle> motorcycles = await motorcycleService.GetAllMotorcyclesAsync();

                LinkMotoProductViewModel model = new()
                {
                    ProductId = productId,
                    Motorcycles = motorcycles
                };

                return View(model);
            }
            catch (Exception)
            {
                return GeneralErrorMessage();
            }
        }

        [HttpPost]
        public async Task<IActionResult> LinkWithMotorcycle(int productId, int motorcycleId)
        {
            try
            {
                await productService.LinkProductMotorcycleAsync(productId, motorcycleId);
                return RedirectToAction("Products", "Admin");
            }
            catch (Exception)
            {
                return GeneralErrorMessage();
            }
        }

        [HttpGet]
        public async Task<IActionResult> LinkWithSpecification(int productId)
        {
            try
            {
                List<Specification> specs = await productService.GetAllSpecificationsAsync();

                LinkSpecProductViewModel model = new()
                {
                    ProductId = productId,
                    Specifications = specs
                };

                return View(model);
            }
            catch (Exception)
            {
                return GeneralErrorMessage();
            }
        }

        [HttpPost]
        public async Task<IActionResult> LinkWithSpecification(int productId, int specificationId)
        {
            try
            {
                await productService.LinkProductSpecificationAsync(productId, specificationId);
                return RedirectToAction("Products", "Admin");
            }
            catch (Exception)
            {
                return GeneralErrorMessage();
            }
        }

        private IActionResult GeneralErrorMessage()
        {
            TempData["ErrorMessage"] = "An unexpected error occurred! Please, try again.";

            return RedirectToAction("Products", "Admin");
        }
    }
}
