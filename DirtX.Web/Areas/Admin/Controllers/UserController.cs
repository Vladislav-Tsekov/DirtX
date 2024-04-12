﻿namespace DirtX.Web.Areas.Admin.Controllers
{
    using DirtX.Core.Interfaces;
    using DirtX.Infrastructure.Data.Models.Users;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class UserController : BaseController
    {
        private readonly IUserService userService;
        //private readonly SignInManager<AppUser> signInManager;

        public UserController(IUserService _userService, /*SignInManager<AppUser> _signInManager*/)
        {
            userService = _userService;
            //signInManager = _signInManager;
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                await userService.DeleteUserAsync(id);

                var previousUrl = Request.Headers["Referer"].ToString();

                return Redirect(previousUrl);
            }
            catch (Exception)
            {
                //TempData error msg?

                var previousUrl = Request.Headers["Referer"].ToString();

                return Redirect(previousUrl);
            }
        }
    }
}
