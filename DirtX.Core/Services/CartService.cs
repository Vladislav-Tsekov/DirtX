using DirtX.Core.Interfaces;
using DirtX.Infrastructure.Data;
using DirtX.Infrastructure.Data.Models.Mappings;
using DirtX.Infrastructure.Data.Models.Products;
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
            CartFormViewModel cart = await context.Carts
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

            if (cart is not null)
                cart.TotalPrice += cart.Products.Select(p => p.TotalPrice).Sum();

            return cart;
        }

        public async Task<CartFormViewModel> GetCartByOrderIdAsync(int orderId)
        {
            CartFormViewModel cart = await context.Orders
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
                .FirstOrDefaultAsync();

            return cart;
        }

        public async Task CreateCartAsync(string userId)
        {
            Cart cart = new()
            {
                UserId = userId,
                DateCreated = DateTime.Now,
            };

            await context.Carts.AddAsync(cart);
            await context.SaveChangesAsync();
        }

        public async Task AddProductToCartAsync(int productId, int cartId, string userId)
        {
            bool productIsInCart = await context.CartsProducts
                .AnyAsync(cp => cp.ProductId == productId && cp.CartId == cartId);

            Cart cart = await context.Carts
                .Where(c => c.Id == cartId)
                .FirstAsync();

            Product product = await context.Products
                .Where(p => p.Id == productId)
                .FirstAsync();

            CartProduct currProduct;

            if (!productIsInCart)
            {
                currProduct = await context.CartsProducts
                 .Where(cp => cp.ProductId == productId && cp.CartId == cartId)
                 .FirstOrDefaultAsync();

                if (currProduct is null)
                {
                    currProduct = new CartProduct()
                    {
                        ProductId = product.Id,
                        CartId = cart.Id
                    };
                }

                await context.CartsProducts.AddAsync(currProduct);
            }
            else
            {
                currProduct = await context.CartsProducts
                    .Where(cp => cp.ProductId == productId && cp.CartId == cartId)
                    .FirstOrDefaultAsync();

                currProduct.Quantity++;
            }

            await context.SaveChangesAsync();
        }

        public async Task RemoveProductFromCartAsync(int productId, int cartId)
        {
            CartProduct cartProduct = await context.CartsProducts
                .Where(cp => cp.ProductId == productId && cp.CartId == cartId)
                .FirstOrDefaultAsync();

            if (cartProduct is not null)
            {
                context.CartsProducts.Remove(cartProduct);
                await context.SaveChangesAsync();
            }
        }

        public async Task IncreaseProductQuantityAsync(int productId, int cartId)
        {
            CartProduct cartProduct = await context.CartsProducts
                .Where(cp => cp.ProductId == productId && cp.CartId == cartId)
                .FirstOrDefaultAsync();

            Product product = await context.Products.Where(p => p.Id == productId).FirstOrDefaultAsync();

            if (product.StockQuantity > cartProduct.Quantity) 
            {
                cartProduct.Quantity++;
            }
            
            await context.SaveChangesAsync();
        }

        public async Task DecreaseProductQuantityAsync(int productId, int cartId)
        {
            CartProduct cartProduct = await context.CartsProducts
                .Where(cp => cp.ProductId == productId && cp.CartId == cartId)
                .FirstOrDefaultAsync();

            cartProduct.Quantity--;

            await context.SaveChangesAsync();
        }
    }
}
