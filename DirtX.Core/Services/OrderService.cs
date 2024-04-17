using DirtX.Core.Interfaces;
using DirtX.Core.Models;
using DirtX.Infrastructure.Data;
using DirtX.Infrastructure.Data.Models.Users;
using DirtX.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace DirtX.Core.Services
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext context;

        public OrderService(ApplicationDbContext _context)
        {
            context = _context;
        }

        public async Task<OrderFormViewModel> GetOrderDetailsAsync(int cartId)
        {
            OrderFormViewModel order = await context.Orders
                .Where(o => o.CartId == cartId)
                .Select(o => new OrderFormViewModel()
                {
                    Id = o.Id,
                    FirstName = o.FirstName,
                    LastName = o.LastName,
                    City = o.City,
                    Address = o.Address,
                    CartId = o.CartId,
                    UserId = o.UserId.ToString(),
                    TotalPrice = o.TotalPrice
                })
                .FirstOrDefaultAsync();

            return order;
        }

        public async Task CreateOrderAsync(OrderFormViewModel orderModel)
        {
            bool isValidUserId = Guid.TryParse(orderModel.UserId, out Guid validUserId);

            if (isValidUserId)
            {
                Order order = new()
                {
                    FirstName = orderModel.FirstName,
                    LastName = orderModel.LastName,
                    City = orderModel.City,
                    Address = orderModel.Address,
                    CartId = orderModel.CartId,
                    UserId = validUserId.ToString(),
                    TotalPrice = orderModel.TotalPrice
                };

                await context.Orders.AddAsync(order);
                await context.SaveChangesAsync();
            }
        }

        public async Task<OrderFormViewModel> GetLastOrderListByUserIdAsync(string userId)
        {
            List<OrderFormViewModel> orderList = await context.Orders
                .Where(o => o.UserId.ToString() == userId)
                .Select(o => new OrderFormViewModel()
                {
                    Id = o.Id,
                    FirstName = o.FirstName,
                    LastName = o.LastName,
                    City = o.City!,
                    Address = o.Address,
                    CartId = o.CartId,
                    UserId = o.UserId.ToString(),
                    TotalPrice = o.TotalPrice
                })
                .ToListAsync();

            OrderFormViewModel lastOrder = orderList.LastOrDefault();

            return (lastOrder);
        }

    }
}
