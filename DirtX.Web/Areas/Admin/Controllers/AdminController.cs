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
        public async Task<IActionResult> Products(int page = 1)
        {
            try
            {
                List<ProductViewModel> allProducts = await productService.GetAllProductsAsync();

                var pageSize = 12;
                var totalProductCount = allProducts.Count();
                var pageCount = (int)Math.Ceiling((double)totalProductCount / pageSize);

                if (page < 1)
                    page = 1;
                else if (page > pageCount)
                    page = pageCount;

                List<ProductViewModel> products = allProducts.Skip((page - 1) * pageSize).Take(pageSize).ToList();

                ViewBag.Page = page;
                ViewBag.TotalCount = totalProductCount;

                return View(products);
            }
            catch (Exception)
            {
                return GeneralErrorMessage();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Users(int page = 1)
        {
            try
            {
                List<UserViewModel> allUsers = await userService.GetAllUsersAsync();

                var pageSize = 12;
                var totalUserCount = allUsers.Count();
                var pageCount = (int)Math.Ceiling((double)totalUserCount / pageSize);

                if (page < 1)
                    page = 1;
                else if (page > pageCount)
                    page = pageCount;

                List<UserViewModel> users = allUsers.Skip((page - 1) * pageSize).Take(pageSize).ToList();

                ViewBag.Page = page;
                ViewBag.TotalCount = totalUserCount;

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
