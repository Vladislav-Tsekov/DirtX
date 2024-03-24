namespace DirtX.Core.Interfaces
{
    public interface ICartService
    {
        //Task<CartFormViewModel?> GetCurrCartByUserIdAsync(string userId);

        //Task<CartFormViewModel> GetCartByOrderIdAsync(string orderId);

        Task CreateCartAsync(string userId);

        Task AddItemToCartAsync(int itemId, string cartId, string userId);

        Task RemoveItemFromCartAsync(int cartItemId, string cartId);

        Task IncreaseItemQuantityAsync(int itemId, string cartId);

        Task DecreaseItemQuantityAsync(int itemId, string cartId);
    }
}
