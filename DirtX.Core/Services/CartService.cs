using DirtX.Core.Interfaces;
using DirtX.Infrastructure.Data.Models.Orders;
using DirtX.Web.Data;
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

        public async Task CreateCartAsync(string userId)
        {
            Cart cart = new()
            {
                UserId = userId
            };

            context.Carts.Add(cart);
            await context.SaveChangesAsync();
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

        public async Task DecreaseProductQuantityAsync(int productId, string cartId)
        {
            var cartProduct = await context
                .CartsProducts
                .Where(ci => ci.ProductId == productId && ci.CartId.ToString() == cartId)
                .FirstAsync();

            cartProduct.Quantity--;

            await context.SaveChangesAsync();
        }

        public Task AddProductToCartAsync(int productId, int cartId, string userId)
        {
            throw new NotImplementedException();
        }

        public Task DecreaseProductQuantityAsync(int productId, int cartId)
        {
            throw new NotImplementedException();
        }
    }
}
