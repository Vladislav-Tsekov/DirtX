using DirtX.Core.Interfaces;
using DirtX.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DirtX.Web.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService cartService;

        public CartController(ICartService _cartService)
        {
            cartService = _cartService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                CartFormViewModel cart = await cartService.GetCartByUserIdAsync(userId);

                return View(cart);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Cart()
        {
            try
            {
                string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                CartFormViewModel cart = await cartService.GetCartByUserIdAsync(userId);

                return View(cart);
            }
            catch (Exception)
            {
                return GeneralErrorMessage();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(int id)
        {
            try
            {
                string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                CartFormViewModel cart = await cartService.GetCartByUserIdAsync(userId);

                if (cart == null)
                {
                    await cartService.CreateCartAsync(userId);

                    cart = await cartService.GetCartByUserIdAsync(userId);
                }

                int cartId = cart.Id;

                await cartService.AddProductToCartAsync(id, cartId, userId);

                return RedirectToAction("Cart", "Cart");
            }
            catch (Exception)
            {
                return GeneralErrorMessage();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Remove(int id)
        {
            try
            {
                string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                CartFormViewModel cart = await cartService.GetCartByUserIdAsync(userId);

                await cartService.RemoveProductFromCartAsync(id, cart!.Id);

                return RedirectToAction("Cart", "Cart");

            }
            catch (Exception)
            {
                return GeneralErrorMessage();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Increase(int id)
        {
            try
            {
                string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                CartFormViewModel cart = await cartService.GetCartByUserIdAsync(userId);

                await cartService.IncreaseProductQuantityAsync(id, cart!.Id);
            }
            catch
            {
                TempData["ErrorMessage"] = "An unexpected error occurred with cart! Please, try again.";

                return RedirectToAction("Cart", "Cart");
            }

            return RedirectToAction("Cart", "Cart");
        }

        [HttpPost]
        public async Task<IActionResult> Decrease(int id)
        {
            try
            {
                string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                CartFormViewModel cart = await cartService.GetCartByUserIdAsync(userId);

                await cartService.DecreaseProductQuantityAsync(id, cart!.Id);
            }
            catch
            {
                TempData["ErrorMessage"] = "An unexpected error occurred with cart! Please, try again.";

                return RedirectToAction("Cart", "Cart");
            }

            return RedirectToAction("Cart", "Cart");
        }

        private IActionResult GeneralErrorMessage()
        {
            TempData["ErrorMessage"] = "An unexpected error occurred with cart! Please, try again.";

            string previousUrl = Request.Headers["Referer"].ToString();

            return Redirect(previousUrl);
        }
    }
}
