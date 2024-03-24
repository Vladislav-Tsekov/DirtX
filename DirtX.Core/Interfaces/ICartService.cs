namespace DirtX.Core.Interfaces
{
    public interface ICartService
    {
        //Task<CartFormViewModel?> GetCurrCartByUserIdAsync(string userId);

        //Task<CartFormViewModel> GetCartByOrderIdAsync(string orderId);

        Task CreateCartAsync(string userId);

        Task AddProductToCartAsync(int productId, int cartId, string userId);

        Task RemoveProductFromCartAsync(int cartProductId, int cartId);

        Task IncreaseProductQuantityAsync(int productId, int cartId);

        Task DecreaseProductQuantityAsync(int productId, int cartId);
    }
}
