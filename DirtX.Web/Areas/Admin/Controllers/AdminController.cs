using DirtX.Core.Interfaces;
using DirtX.Core.Models.Admin;
using DirtX.Infrastructure.Data.Models.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DirtX.Web.Areas.Admin.Controllers
{
    public class AdminController : BaseController
    {
        private readonly IProductService productService;
        private readonly IUserService userService;
        private readonly UserManager<AppUser> userManager;

        public AdminController(IProductService _productService, IUserService _userService, UserManager<AppUser> _userManager)
        {
            productService = _productService;
            userService = _userService;
            userManager = _userManager;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var allProducts = await productService.GetAllProductsAsync();
                var allUsers = await userService.GetAllUsersAsync();

                AdminIndexViewModel model = new()
                {
                    Users = allUsers,
                    Products = allProducts,
                };

                return View(model);
            }
            catch (Exception)
            {
                return GeneralErrorMessage();
            }
        }

        //public async Task<IActionResult> Products([FromQuery] AllProductsQueryModel queryModel)
        //{
        //    try
        //    {
        //        var allProducts = await productService.AllIVisibletemsQueryAsync(queryModel);

        //        queryModel.Products = allProducts.Products;
        //        queryModel.TotalProducts = allProducts.TotalProductsCount;
        //        queryModel.Categories = await categoryService.AllCategoriesNameAsync();

        //        foreach (var product in allProducts.Products)
        //        {
        //            await imageService.DownloadImageAsync(product.Image);
        //        }

        //        return View(queryModel);
        //    }
        //    catch (Exception)
        //    {
        //        return GeneralErrorMessage();
        //    }
        //}

        //public async Task<IActionResult> Users([FromQuery] AllUsersQueryModel queryModel)
        //{
        //    try
        //    {
        //        var allUsers = await userService.AllUsersQueryAsync(queryModel);

        //        queryModel.Users = allUsers.Users;
        //        queryModel.TotalUsers = allUsers.TotalUsersCount;

        //        return View(queryModel);
        //    }
        //    catch (Exception)
        //    {
        //        return GeneralErrorMessage();
        //    }
        //}

        [HttpPost]
        public async Task<IActionResult> SetRole(string userId)
        {
            var user = await userManager.FindByIdAsync(userId);
            var roles = await userManager.GetRolesAsync(user);
            bool isReseller = roles.Any(r => r.Contains("Reseller"));

            try
            {
                if (!isReseller)
                {
                    await userManager.AddToRoleAsync(user, "Reseller");
                }
                else if (isReseller)
                {
                    await userManager.RemoveFromRoleAsync(user, "Reseller");
                }

                var previousUrl = Request.Headers["Referer"].ToString();

                return Redirect(previousUrl);
            }
            catch (Exception)
            {
                return GeneralErrorMessage();
            }
        }

        private IActionResult GeneralErrorMessage()
        {
            TempData["ErrorMessage"] = "An unexpected error occurred! Please, try again.";

            var previousUrl = Request.Headers["Referer"].ToString();

            return Redirect(previousUrl);
        }
    }
}
