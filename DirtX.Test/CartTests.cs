using DirtX.Core.Services;
using DirtX.Infrastructure.Data;
using DirtX.Infrastructure.Data.Models.Mappings;
using DirtX.Infrastructure.Data.Models.Products;
using DirtX.Infrastructure.Data.Models.Users;
using Microsoft.EntityFrameworkCore;

namespace DirtX.Test
{
    public class CartTests
    {
        [Test]
        public async Task GetCartByUserIdAsyncReturnsCartWithProducts()
        {
            var userId = "user123";
            int cartId = 6;
            var contextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "DirtXTest")
                .Options;

            using (var context = new ApplicationDbContext(contextOptions))
            {
                context.Carts.Add(new Cart
                {
                    Id = cartId,
                    UserId = userId,
                    DateCreated = DateTime.Now,
                    CartProducts = new[]
                    {
                        new CartProduct
                        {
                            ProductId = 10,
                            Quantity = 2,
                            Product = new Product
                            {
                                Id = 10,
                                Title = "Test Product",
                                ImageUrl = "testimage.jpg",
                                Description = "Test Description test asd asd asd",
                                Price = 10.0m
                            }
                        }
                    }
                });
                await context.SaveChangesAsync();
            }

            using (var context = new ApplicationDbContext(contextOptions))
            {
                var cartService = new CartService(context);

                var result = await cartService.GetCartByUserIdAsync(userId);

                Assert.That(result, Is.Not.Null);
                Assert.That(result.Id, Is.EqualTo(cartId));
                Assert.That(result.Products, Is.Not.Null);

                var product = result.Products.First();

                Assert.That(product.Title, Is.EqualTo("Test Product"));
                Assert.That(product.Image, Is.EqualTo("testimage.jpg"));
                Assert.That(product.Price, Is.EqualTo(10.0));
                Assert.That(product.Quantity, Is.EqualTo(2));
                Assert.That(product.TotalPrice, Is.EqualTo(20.0));
            }
        }

        [Test]
        public async Task GetCartByOrderIdAsyncReturnsCartWithProducts()
        {
            var orderId = 2;
            int cartId = 2;
            var contextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "DirtXTest")
                .Options;

            using (var context = new ApplicationDbContext(contextOptions))
            {
                context.Orders.Add(new Order
                {
                    Id = orderId,
                    CartId = cartId,
                    Address = "Asd fgh",
                    City = "Sofia",
                    FirstName = "Rado",
                    LastName = "Penev",
                    Cart = new Cart
                    {
                        Id = cartId,
                        DateCreated = DateTime.Now,
                        CartProducts = new[]
                        {
                            new CartProduct
                            {
                                ProductId = 5,
                                Quantity = 3,
                                Product = new Product
                                {
                                    Id = 5,
                                    Title = "Test Product",
                                    ImageUrl = "testimage.jpg",
                                    Description = "Test asd fgh jkl qwe ert asd zxc asd",
                                    Price = 10.0m
                                }
                            }
                        }
                    }
                });
                await context.SaveChangesAsync();
            }

            using (var context = new ApplicationDbContext(contextOptions))
            {
                var cartService = new CartService(context);

                var result = await cartService.GetCartByOrderIdAsync(orderId);

                Assert.That(result, Is.Not.Null);
                Assert.That(result.Id, Is.EqualTo(cartId));
                Assert.That(result.Products, Is.Not.Null);

                var product = result.Products.First();

                Assert.That(product.ProductId, Is.EqualTo(5));
                Assert.That(product.Title, Is.EqualTo("Test Product"));
                Assert.That(product.Image, Is.EqualTo("testimage.jpg"));
                Assert.That(product.Price, Is.EqualTo(10.0));
                Assert.That(product.Quantity, Is.EqualTo(3));
                Assert.That(product.TotalPrice, Is.EqualTo(30.0));
            }
        }

        [Test]
        public async Task CreateCartAsyncCreatesNewCart()
        {
            var userId = "testUserId";
            var contextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "DirtXTest")
                .Options;

            using var context = new ApplicationDbContext(contextOptions);

            var cartService = new CartService(context);

            await cartService.CreateCartAsync(userId);

            var createdCart = await context.Carts.FirstOrDefaultAsync(c => c.UserId == userId);

            Assert.That(createdCart, Is.Not.Null);
            Assert.That(createdCart.UserId, Is.EqualTo(userId));
            Assert.That(createdCart.DateCreated <= DateTime.Now, Is.True);
        }

        [Test]
        public async Task RemoveProductFromCartAsyncRemovesProductFromCart()
        {
            var productId = 25;
            var cartId = 20;
            var cartProduct = new CartProduct { ProductId = productId, CartId = cartId };

            var contextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "DirtXTest")
                .Options;

            using var context = new ApplicationDbContext(contextOptions);
            await context.CartsProducts.AddAsync(cartProduct);
            await context.SaveChangesAsync();

            var cartService = new CartService(context);

            await cartService.RemoveProductFromCartAsync(productId, cartId);

            var removedProduct = await context.CartsProducts
                .FirstOrDefaultAsync(cp => cp.ProductId == productId && cp.CartId == cartId);

            Assert.That(removedProduct, Is.Null);
        }

        [Test]
        public async Task DecreaseProductQuantityAsyncDecreasesProductQuantity()
        {
            var productId = 1;
            var cartId = 1;
            var cartProduct = new CartProduct { ProductId = productId, CartId = cartId, Quantity = 2 };

            var contextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "DirtXTest")
                .Options;

            using (var context = new ApplicationDbContext(contextOptions))
            {
                await context.CartsProducts.AddAsync(cartProduct);
                await context.SaveChangesAsync();

                var cartService = new CartService(context);

                await cartService.DecreaseProductQuantityAsync(productId, cartId);

                var updatedCartProduct = await context.CartsProducts.FirstOrDefaultAsync(cp => cp.ProductId == productId && cp.CartId == cartId);
                Assert.IsNotNull(updatedCartProduct);
                Assert.That(updatedCartProduct.Quantity, Is.EqualTo(1));
            }
        }
    }
}
