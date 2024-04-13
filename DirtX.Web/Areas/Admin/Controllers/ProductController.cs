using DirtX.Core.Interfaces;
using DirtX.Core.Models.Admin;
using Microsoft.AspNetCore.Mvc;

namespace DirtX.Web.Areas.Admin.Controllers
{
    public class ProductController : BaseController
    {
        //TODO - ADD LOGGER
        private readonly IProductService productService;

        public ProductController(IProductService _productService)
        {
            productService = _productService;
        }

        //TODO - ADD NEW PRODUCT SPECIFICATIONS / PROD.SPEC.TITLES
        //TODO - ADD PRODUCT SPECIFICATIONS FOR EXISTING PRODUCT
        //TODO - ADD BRAND
        //TODO - ADD COMPATIBLE MOTORCYCLES IF THE PRODUCT TYPE IS "PART"

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            try
            {
                var model = new ProductFormViewModel()
                {
                    //TODO - ADD LOGIC
                };

                return View(model);
            }
            catch (Exception)
            {
                return GeneralErrorMessage();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProductFormViewModel model)
        {
            //TODO - MUST CHOOSE PRODUCT TYPE AND THEN CATEGORY SOMEHOW FIRST

            if (/*type exists*/false)
            {
                ModelState.AddModelError(nameof(model/*.Type*/), "Invalid Product Type");
            }

            //TODO - ADMIN MUST CHOOSE EXISTING BRAND/BRANDID LIKE I DID IN THE USED/SELL OR ADD A NEW BRAND (REDIRECT)

            if (!ModelState.IsValid)
            {
                TempData["ErrorMessage"] = "An unexpected error occurred! Please, try again.";

                return View(model);
            }

            try
            {
                await productService.AddProductAsync(model);
            }
            catch (Exception)
            {
                TempData["ErrorMessage"] = "An unexpected error occurred! Please, try again.";

                return View(model);
            }

            TempData["SuccessMessage"] = "Your product have been added successfully.";
            //TODO - WHERE TO REDIRECT?
            return Redirect("");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var currProduct = await productService.GetProductAsync(id);
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

            TempData["SuccessMessage"] = "You edited the product successfully.";
            return RedirectToAction("Products", "Admin");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await productService.DeleteProductAsync(id);
                TempData["SuccessMessage"] = "You deleted the product successfully.";
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
