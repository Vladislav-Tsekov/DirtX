using DirtX.Core.Interfaces;
using DirtX.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DirtX.Web.Controllers
{
    [Authorize]
    public class CartController : BaseController
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

                if (cart is null)
                {
                    return NotFound();
                }

                return View(cart);
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(Error));
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
                return RedirectToAction(nameof(Error));
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

                return RedirectToAction(nameof(Cart), "Cart");
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(Error));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Remove(int id)
        {
            try
            {
                string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                CartFormViewModel cart = await cartService.GetCartByUserIdAsync(userId);

                await cartService.RemoveProductFromCartAsync(id, cart.Id);

                return RedirectToAction(nameof(Cart), "Cart");

            }
            catch (Exception)
            {
                return RedirectToAction(nameof(Error));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Increase(int id)
        {
            try
            {
                string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                CartFormViewModel cart = await cartService.GetCartByUserIdAsync(userId);

                await cartService.IncreaseProductQuantityAsync(id, cart.Id);
            }
            catch
            {
                return RedirectToAction(nameof(Error));
            }

            return RedirectToAction(nameof(Cart), "Cart");
        }

        [HttpPost]
        public async Task<IActionResult> Decrease(int id)
        {
            try
            {
                string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                CartFormViewModel cart = await cartService.GetCartByUserIdAsync(userId);

                await cartService.DecreaseProductQuantityAsync(id, cart.Id);
            }
            catch
            {
                return RedirectToAction(nameof(Error));
            }

            return RedirectToAction(nameof(Cart), "Cart");
        }
    }
}
