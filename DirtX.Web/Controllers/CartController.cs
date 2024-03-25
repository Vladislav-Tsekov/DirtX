using DirtX.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DirtX.Web.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService cartService;

        public CartController(ICartService cartService)
        {
            this.cartService = cartService;
        }

        //[HttpGet]
        //public async Task<IActionResult> Index()
        //{
        //    try
        //    {
        //        //TODO = IMPLEMENT USER FIRST
        //        var userId =
        //        var cart = await cartService.GetCartByUserIdAsync(userId);

        //        return View(cart);
        //    }
        //    catch (Exception)
        //    {
        //        return GeneralErrorMessage();
        //    }
        //}
    }
}
