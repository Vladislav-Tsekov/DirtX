using DirtX.Core.Interfaces;
using DirtX.Core.Models.Admin;
using DirtX.Infrastructure.Data.Models.Users;
using DirtX.Scraper;
using DirtX.Scraper.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DirtX.Web.Areas.Admin.Controllers
{
    public class AdminController : BaseController
    {
        private readonly IProductService productService;
        private readonly IUserService userService;
        private readonly UserManager<AppUser> userManager;
        private readonly IScraperService scraperService;

        public AdminController(IProductService _productService, IUserService _userService, 
                               UserManager<AppUser> _userManager, IScraperService _scraperService)
        {
            productService = _productService;
            userService = _userService;
            userManager = _userManager;
            scraperService = _scraperService;
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

                int pageSize = 12;
                int totalProductCount = allProducts.Count;
                int pageCount = (int)Math.Ceiling((double)totalProductCount / pageSize);

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

                int pageSize = 12;
                int totalUserCount = allUsers.Count;
                int pageCount = (int)Math.Ceiling((double)totalUserCount / pageSize);

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

        [HttpGet]
        public async Task<IActionResult> Scrape()
        {
            string result = await scraperService.RunScraper();
            ViewBag.Result = result;

            string outputDirectory = scraperService.GetScraperOutputFolder();

            string[] csvFiles = Directory.GetFiles(outputDirectory, "*.csv");

            ViewBag.FileNames = csvFiles.Select(Path.GetFileName).ToList();

            return View();
        }

        [HttpPost]
        public IActionResult DownloadFile(string fileName)
        {
            string outputDirectory = scraperService.GetScraperOutputFolder();

            string filePath = Path.Combine(outputDirectory, fileName);

            byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);
            return File(fileBytes, "application/octet-stream", fileName);
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
