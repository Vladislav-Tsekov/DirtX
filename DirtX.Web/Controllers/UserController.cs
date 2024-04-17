using DirtX.Core.Interfaces;
using DirtX.Core.Models;
using DirtX.Infrastructure.Data.Models.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DirtX.Web.Controllers
{
    [Authorize]
    public class UserController : BaseController
    {
        private readonly IUserService userService;
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;

        public UserController(IUserService _userService, UserManager<AppUser> _userManager, SignInManager<AppUser> _signInManager)
        {
            userService = _userService;
            userManager = _userManager;
            signInManager = _signInManager;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginModel)
        {
            if (!ModelState.IsValid)
            {
                return View(loginModel);
            }

            AppUser user = await userManager.FindByEmailAsync(loginModel.Email);

            if (user is not null)
            {
                var result = await signInManager.PasswordSignInAsync(user, loginModel.Password, loginModel.RememberMe, lockoutOnFailure: true);

                if (result.IsLockedOut)
                {
                    ModelState.AddModelError(string.Empty, "The account is locked. Too many attempts! Try again later");
                }

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            return View(loginModel);
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel regModel)
        {
            if (!ModelState.IsValid)
            {
                return View(regModel);
            }

            AppUser user = await userManager.FindByEmailAsync(regModel.Email);

            if (user is not null)
            {
                TempData["ErrorMessage"] = "User with this email already exists!";

                return View(regModel);
            }

            user = new AppUser();

            await userManager.SetEmailAsync(user, regModel.Email);

            user.UserName = user.Email;

            var result = await userManager.CreateAsync(user, regModel.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

                return View(regModel);
            }

            await userManager.AddToRoleAsync(user, "User");
            await signInManager.SignInAsync(user, false);

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> Details()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            try
            {
                var currUser = await userService.GetUserByIdAsync(userId);

                if (currUser is null)
                {
                    return NotFound();
                }

                return View(currUser);
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(Error));
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            try
            {
                EditProfileViewModel editUserModel = await userService.GetUserByIdAsync(userId);

                if (editUserModel is null)
                {
                    return NotFound();
                }

                return View(editUserModel);
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(Error));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditProfileViewModel editModel)
        {
            List<UserViewModel> users = await userService.GetAllUsersWithoutCurrentAsync(editModel.Id);

            if (users.Any(u => u.Email == editModel.Email))
            {
                ModelState.AddModelError("Email", "This email address is already used");
            }
            if (editModel.Email is not null && users.Any(u => u.Email.ToLower() == editModel.Email.ToLower()))
            {
                ModelState.AddModelError("UserName", "This Username is already used");
            }

            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            EditProfileViewModel user = await userService.GetUserByIdAsync(userId);

            if (!ModelState.IsValid)
            {
                editModel.Email = user.Email;

                return View(editModel);
            }

            try
            {
                await userService.EditProfileAsync(userId, editModel);
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(Error));
            }

            return RedirectToAction("Details", "User");
        }

        [HttpPost]
        public async Task<IActionResult> Delete()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            try
            {
                await userService.DeleteUser(userId);

                await signInManager.SignOutAsync();
                return RedirectToAction("Index", "Home");
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(Error));
            }
        }

        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(UserChangePasswordViewModel model)
        {
            try
            {
                if (model.NewPassword != model.ConfirmPassword)
                {
                    ModelState.AddModelError(string.Empty, "Confirm Password doesn't match!");
                }

                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                var user = await userManager.GetUserAsync(User);

                if (user is null)
                {
                    return NotFound();
                }

                var changePasswordResult = await userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);

                if (!changePasswordResult.Succeeded)
                {
                    foreach (var error in changePasswordResult.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    return View(model);
                }

                await signInManager.SignOutAsync();

                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return RedirectToAction(nameof(Error));
            }
        }
    }
}
