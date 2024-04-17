namespace DirtX.Web.Areas.Admin.Controllers
{
    using DirtX.Core.Interfaces;
    using DirtX.Infrastructure.Data.Models.Users;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System.Security.Claims;

    public class UserController : AdminBaseController
    {
        private readonly IUserService userService;
        private readonly UserManager<AppUser> userManager;

        public UserController(IUserService _userService, UserManager<AppUser> _userManager)
        {
            userService = _userService;
            userManager = _userManager;
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string userId)
        {
            AppUser user = await userManager.FindByIdAsync(userId);

            try
            {
                await userService.DeleteUser(user.Id);

                return RedirectToAction("Users", "Admin");
            }
            catch (Exception)
            {
                TempData["ErrorMessage"] = "Delete was unsuccessful!";

                return RedirectToAction("Users", "Admin");
            }
        }

        [HttpPost]
        public async Task<IActionResult> ToggleAdmin(string userId)
        {
            AppUser user = await userManager.FindByIdAsync(userId);
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

                await userService.ToggleUserAdmin(userId);

                return RedirectToAction("Users", "Admin");
            }
            catch (Exception)
            {
                return GeneralErrorMessage();
            }
        }

        private IActionResult GeneralErrorMessage()
        {
            TempData["ErrorMessage"] = "An unexpected error occurred! Please, try again.";

            return RedirectToAction("Index", "Admin");
        }
    }
}
