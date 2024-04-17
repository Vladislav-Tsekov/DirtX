using DirtX.Core.Interfaces;
using DirtX.Core.Models;
using DirtX.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DirtX.Web.Controllers
{
    public class OrderController : BaseController
    {
        private readonly IOrderService orderService;
        private readonly ICartService cartService;
        private readonly IProductService productService;

        public OrderController(IOrderService _orderService, ICartService _cartService, IProductService _productService)
        {
            orderService = _orderService;
            cartService = _cartService;
            productService = _productService;
        }

        [HttpGet]
        public async Task<IActionResult> Checkout()
        {
            try
            {
                string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                CartFormViewModel currCart = await cartService.GetCartByUserIdAsync(userId);

                if (currCart is null)
                {
                    return NotFound();
                }

                OrderFormViewModel order = new()
                {
                    TotalPrice = currCart.TotalPrice
                };

                return View(order);
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(Error));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Checkout(OrderFormViewModel order)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            CartFormViewModel model = await cartService.GetCartByUserIdAsync(userId);

            order.UserId = userId;
            order.CartId = model.Id;
            order.TotalPrice = model.TotalPrice;

            if (!ModelState.IsValid)
            {
                order.TotalPrice = model.TotalPrice;

                return View(order);
            }

            try
            {
                await orderService.CreateOrderAsync(order);
                await cartService.CreateCartAsync(userId);
                await productService.UpdateStockQuantityAsync(order);
            }
            catch (Exception)
            {
                return View(order);
            }

            return RedirectToAction(nameof(Confirmed));
        }

        [HttpGet]
        public IActionResult Confirmed()
        {
            return View();
        }
    }
}
