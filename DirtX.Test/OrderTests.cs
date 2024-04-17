using DirtX.Core.Services;
using DirtX.Infrastructure.Data;
using DirtX.Infrastructure.Data.Models.Users;
using Microsoft.EntityFrameworkCore;

namespace DirtX.Test
{
    public class OrderServiceTests
    {
        [Test]
        public async Task GetOrderDetailsAsyncReturnsOrderDetails()
        {
            int cartId = 27;
            var order = new Order
            {
                Id = 27,
                FirstName = "John",
                LastName = "Doe",
                City = "New York",
                Address = "123 Main St",
                CartId = cartId,
                UserId = Guid.NewGuid().ToString(),
                TotalPrice = 100.0m
            };

            var contextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "DirtXTest")
                .Options;

            using (var context = new ApplicationDbContext(contextOptions))
            {
                context.Orders.Add(order);
                await context.SaveChangesAsync();
            }

            using (var context = new ApplicationDbContext(contextOptions))
            {
                var orderService = new OrderService(context);

                var result = await orderService.GetOrderDetailsAsync(cartId);

                Assert.That(result, Is.Not.Null);
                Assert.That(result.Id, Is.EqualTo(order.Id));
                Assert.That(result.FirstName, Is.EqualTo(order.FirstName));
                Assert.That(result.LastName, Is.EqualTo(order.LastName));
                Assert.That(result.City, Is.EqualTo(order.City));
                Assert.That(result.Address, Is.EqualTo(order.Address));
                Assert.That(result.CartId, Is.EqualTo(order.CartId));
                Assert.That(result.UserId, Is.EqualTo(order.UserId));
                Assert.That(result.TotalPrice, Is.EqualTo(order.TotalPrice));
            }
        }

        [Test]
        public async Task GetLastOrderListByUserIdAsyncReturnsLastOrder()
        {
            var userId = Guid.NewGuid().ToString();
            var orders = new List<Order>
            {
                new Order
                {
                    Id = 5,
                    FirstName = "John",
                    LastName = "Doe",
                    City = "New York",
                    Address = "123 Main St",
                    CartId = 2,
                    UserId = userId,
                    TotalPrice = 100.0m
                },
                new Order
                {
                    Id = 4,
                    FirstName = "Jane",
                    LastName = "Smith",
                    City = "Los Angeles",
                    Address = "456 Elm St",
                    CartId = 3,
                    UserId = userId,
                    TotalPrice = 150.0m
                }
            };

            var contextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "DirtXTest")
                .Options;

            using (var context = new ApplicationDbContext(contextOptions))
            {
                context.Orders.AddRange(orders);
                await context.SaveChangesAsync();
            }

            using (var context = new ApplicationDbContext(contextOptions))
            {
                var orderService = new OrderService(context);

                var result = await orderService.GetLastOrderListByUserIdAsync(userId);

                Assert.That(result, Is.Not.Null);
                Assert.That(result.Id, Is.EqualTo(4));
                Assert.That(result.FirstName, Is.EqualTo("Jane"));
                Assert.That(result.LastName, Is.EqualTo("Smith"));
                Assert.That(result.City, Is.EqualTo("Los Angeles"));
                Assert.That(result.Address, Is.EqualTo("456 Elm St"));
                Assert.That(result.CartId, Is.EqualTo(3));
                Assert.That(result.UserId, Is.EqualTo(userId));
                Assert.That(result.TotalPrice, Is.EqualTo(150.0m));
            }
        }
    }
}
