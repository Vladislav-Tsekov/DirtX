using DirtX.Core.Enums;
using DirtX.Core.Interfaces;
using DirtX.Core.Models.Admin;
using DirtX.Infrastructure.Data.Models.Products;
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

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                var users = await userService.GetAllUsersAsync();
                var products = await productService.GetAllProductsAsync();

                AdminIndexViewModel model = new()
                {
                    Users = users,
                    Products = products,
                };

                return View(model);
            }
            catch (Exception)
            {
                return GeneralErrorMessage();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Products()
        {
            try
            {
                List<ProductViewModel> products = await productService.GetAllProductsAsync();

                return View(products);
            }
            catch (Exception)
            {
                return GeneralErrorMessage();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Users()
        {
            try
            {
                var users = await userService.GetAllUsersAsync();

                return View(users);
            }
            catch (Exception)
            {
                return GeneralErrorMessage();
            }
        }

        [HttpPost]
        public async Task<IActionResult> ToggleReseller(string userId)
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

                string previousUrl = Request.Headers["Referer"].ToString();

                return Redirect(previousUrl);
            }
            catch (Exception)
            {
                return GeneralErrorMessage();
            }
        }

        [HttpPost]
        public async Task<IActionResult> ToggleAdmin(string userId)
        {
            var user = await userManager.FindByIdAsync(userId);
            var roles = await userManager.GetRolesAsync(user);
            bool isAdmin = roles.Any(r => r.Contains("Admin"));

            try
            {
                if (!isAdmin)
                {
                    await userManager.AddToRoleAsync(user, "Admin");
                }
                else if (isAdmin)
                {
                    await userManager.RemoveFromRoleAsync(user, "Admin");
                }

                string previousUrl = Request.Headers["Referer"].ToString();

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

            string previousUrl = Request.Headers["Referer"].ToString();

            return Redirect(previousUrl);
        }
    }
}
