using DirtX.Core.Interfaces;
using DirtX.Infrastructure.Data;
using DirtX.Infrastructure.Data.Models.Users;
using DirtX.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace DirtX.Core.Services
{
    public class CartService : ICartService
    {
        private readonly ApplicationDbContext context;

        public CartService(ApplicationDbContext _context)
        {
            context = _context;
        }

        public async Task<CartFormViewModel> GetCartByUserIdAsync(string userId)
        {
            CartFormViewModel cart = await context
                .Carts
                .OrderByDescending(c => c.DateCreated)
                .Where(c => c.UserId == userId)
                .Select(c => new CartFormViewModel()
                {
                    Id = c.Id,
                    Products = c.CartProducts
                    .Select(cp => new CartProductViewModel()
                    {
                        ProductId = cp.ProductId,
                        Title = cp.Product.Title,
                        Image = cp.Product.ImageUrl,
                        Price = cp.Product.Price,
                        Quantity = cp.Quantity,
                        TotalPrice = cp.Quantity * cp.Product.Price
                    })
                    .ToArray()
                })
                .FirstOrDefaultAsync();

            if (cart != null)
                cart.TotalPrice += cart.Products.Select(p => p.TotalPrice).Sum();

            return cart;
        }

        public async Task<CartFormViewModel> GetCartByOrderIdAsync(int orderId)
        {
            CartFormViewModel cart = await context
                .Orders
                .Where(o => o.Id == orderId)
                .Select(o => new CartFormViewModel()
                {
                    Id = o.CartId,
                    Products = o.Cart.CartProducts
                    .Select(cp => new CartProductViewModel()
                    {
                        ProductId = cp.ProductId,
                        Title = cp.Product.Title,
                        Image = cp.Product.ImageUrl,
                        Price = cp.Product.Price,
                        Quantity = cp.Quantity,
                        TotalPrice = cp.Quantity * cp.Product.Price
                    })
                    .ToArray()
                })
                .FirstAsync();

            //TODO - POSSIBLE NULL REFERENCE?

            return cart;
        }

        public async Task CreateCartAsync(string userId)
        {
            Cart cart = new()
            {
                UserId = userId
            };

            context.Carts.Add(cart);
            await context.SaveChangesAsync();
        }

        public async Task AddProductToCartAsync(int productId, int cartId, string userId)
        {
            //TODO - IN ORDER TO IMPLEMENT THIS METHOD A SERIOUS DATABASE REMODELLING IS REQUIRED - INSTEAD OF TPH APPROACH ONE TABLE FOR PRODUCTS MUST BE USED
        }

        public async Task RemoveProductFromCartAsync(int productId, int cartId)
        {
            var cartProduct = await context
                .CartsProducts
                .Where(cp => cp.ProductId == productId && cp.CartId == cartId)
                .FirstOrDefaultAsync();

            if (cartProduct != null)
            {
                context.CartsProducts.Remove(cartProduct);
                await context.SaveChangesAsync();
            }
        }

        public async Task IncreaseProductQuantityAsync(int productId, int cartId)
        {
            var cartProduct = await context
                .CartsProducts
                .Where(cp => cp.ProductId == productId && cp.CartId == cartId)
                .FirstAsync();

            cartProduct.Quantity++;

            await context.SaveChangesAsync();
        }

        public async Task DecreaseProductQuantityAsync(int productId, int cartId)
        {
            var cartProduct = await context
                .CartsProducts
                .Where(cp => cp.ProductId == productId && cp.CartId == cartId)
                .FirstAsync();

            cartProduct.Quantity--;

            await context.SaveChangesAsync();
        }
    }
}
