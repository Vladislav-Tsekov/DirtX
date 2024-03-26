using DirtX.Web.Models;

namespace DirtX.Core.Interfaces
{
    public interface ICartService
    {
        Task<CartFormViewModel> GetCartByUserIdAsync(string userId);

        Task<CartFormViewModel> GetCartByOrderIdAsync(int orderId);

        Task CreateCartAsync(string userId);

        Task AddProductToCartAsync(int productId, int cartId, string userId);

        Task RemoveProductFromCartAsync(int cartProductId, int cartId);

        Task IncreaseProductQuantityAsync(int productId, int cartId);

        Task DecreaseProductQuantityAsync(int productId, int cartId);
    }
}
