using DirtX.Core.Models;

namespace DirtX.Core.Interfaces
{
    public interface IOrderService
    {
        Task<OrderFormViewModel> GetOrderDetailsAsync(int cartId);

        Task CreateOrderAsync(OrderFormViewModel model);

        Task<OrderFormViewModel> GetLastOrderListByUserIdAsync(string userId);
    }
}
