using DirtX.Core.Interfaces;
using DirtX.Core.Models;
using DirtX.Core.Services;
using DirtX.Infrastructure.Data;
using DirtX.Infrastructure.Data.Models.Users;
using DirtX.Web.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;

namespace DirtX.Test
{
    public class UserTests
    {
        [Test]
        public async Task RegisterReturnsRedirectToIndexWhenRegistrationSuccessful()
        {
            var userServiceMock = new Mock<IUserService>();

            var userManagerMock = new Mock<UserManager<AppUser>>(
                Mock.Of<IUserStore<AppUser>>(), null!, null!, null!, null!, null!, null!, null!, null!);

            var signInManagerMock = new Mock<SignInManager<AppUser>>(
                userManagerMock.Object, Mock.Of<IHttpContextAccessor>(), Mock.Of<IUserClaimsPrincipalFactory<AppUser>>(), null!, null!, null!, null!);

            var loggerMock = Mock.Of<ILogger<UserController>>();

            var registerViewModel = new RegisterViewModel
            {
                Email = "test@example.com",
                Password = "Password123!",
                ConfirmPassword = "Password123!"
            };

            userManagerMock.Setup(m => m.FindByEmailAsync(registerViewModel.Email)).ReturnsAsync((AppUser)null!);
            userManagerMock.Setup(m => m.CreateAsync(It.IsAny<AppUser>(), registerViewModel.Password)).ReturnsAsync(IdentityResult.Success);
            signInManagerMock.Setup(m => m.SignInAsync(It.IsAny<AppUser>(), false, null)).Returns(Task.CompletedTask);

            var controller = new UserController(userServiceMock.Object, userManagerMock.Object, signInManagerMock.Object);

            var result = await controller.Register(registerViewModel) as RedirectToActionResult;

            Assert.That(result, Is.Not.Null);
            Assert.That(result.ActionName, Is.EqualTo("Index"));
            Assert.That(result.ControllerName, Is.EqualTo("Home"));
        }

        [Test]
        public async Task LoginReturnsRedirectToIndexWhenLoginSuccessful()
        {
            var userServiceMock = new Mock<IUserService>();

            var userManagerMock = new Mock<UserManager<AppUser>>(
                Mock.Of<IUserStore<AppUser>>(), null!, null!, null!, null!, null!, null!, null!, null!);

            var signInManagerMock = new Mock<SignInManager<AppUser>>(
                userManagerMock.Object, Mock.Of<IHttpContextAccessor>(), Mock.Of<IUserClaimsPrincipalFactory<AppUser>>(), null!, null!, null!, null!);

            var loginViewModel = new LoginViewModel
            {
                Email = "test@example.com",
                Password = "Password123!",
                RememberMe = false
            };

            var user = new AppUser { Email = loginViewModel.Email };

            userManagerMock.Setup(m => m.FindByEmailAsync(loginViewModel.Email)).ReturnsAsync(user);
            signInManagerMock.Setup(m => m.PasswordSignInAsync(user, loginViewModel.Password, loginViewModel.RememberMe, true))
                             .ReturnsAsync(Microsoft.AspNetCore.Identity.SignInResult.Success);

            var controller = new UserController(userServiceMock.Object, userManagerMock.Object, signInManagerMock.Object);

            var result = await controller.Login(loginViewModel) as RedirectToActionResult;

            Assert.That(result, Is.Not.Null);
            Assert.That(result.ActionName, Is.EqualTo("Index"));
            Assert.That(result.ControllerName, Is.EqualTo("Home"));
        }

        [Test]
        public async Task DeleteUserValidUserIdDeletesUser()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "DirtXTest")
                .Options;

            string testUserId;

            using (var context = new ApplicationDbContext(options))
            {
                testUserId = Guid.NewGuid().ToString();
                var testUser = new AppUser { Id = testUserId };
                context.Users.Add(testUser);
                context.SaveChanges();
            }

            using (var context = new ApplicationDbContext(options))
            {
                var userService = new UserService(context);

                await userService.DeleteUser(testUserId);

                var user = await context.Users.FirstOrDefaultAsync(u => u.Id == testUserId);
                Assert.That(user, Is.Null);
            }
        }

        [Test]
        public async Task DeleteUserInvalidUserIdReturnsException()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "DirtXTest")
                .Options;

            using var context = new ApplicationDbContext(options);
            var userService = new UserService(context);

            var exception = Assert.ThrowsAsync<Exception>(async () => await userService.DeleteUser("invalidUserId"));

            Assert.That(exception.Message, Is.EqualTo("User not found!"));
        }

        [Test]
        public async Task GetAllUsersWithoutCurrentAsyncInvalidUserIdReturnsNull()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "DirtXTest")
                .Options;

            using var context = new ApplicationDbContext(options);

            var userService = new UserService(context);

            var users = await userService.GetAllUsersWithoutCurrentAsync("invalidUserId");

            Assert.That(users, Is.Null);
        }

        [Test]
        public async Task GetUserByIdAsyncReturnsCorrectUser()
        {
            var userId = "00000000-0000-0000-0000-000000000001";
            var expectedUserModel = new EditProfileViewModel
            {
                Id = userId,
                Email = "test@example.com",
                FirstName = "John",
                LastName = "Doe",
                Country = "USA",
                City = "New York",
                Address = "123 Main St"
            };

            var contextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "DirtXTest")
                .Options;

            using (var context = new ApplicationDbContext(contextOptions))
            {
                context.Users.Add(new AppUser
                {
                    Id = userId,
                    Email = expectedUserModel.Email,
                    FirstName = expectedUserModel.FirstName,
                    LastName = expectedUserModel.LastName,
                    Country = expectedUserModel.Country,
                    City = expectedUserModel.City,
                    Address = expectedUserModel.Address
                });
                await context.SaveChangesAsync();
            }

            using (var context = new ApplicationDbContext(contextOptions))
            {
                var userService = new UserService(context);

                // Act
                var result = await userService.GetUserByIdAsync(userId);

                // Assert
                Assert.NotNull(result);
                Assert.That(result.Id, Is.EqualTo(expectedUserModel.Id));
                Assert.That(result.Email, Is.EqualTo(expectedUserModel.Email));
                Assert.That(result.FirstName, Is.EqualTo(expectedUserModel.FirstName));
                Assert.That(result.LastName, Is.EqualTo(expectedUserModel.LastName));
                Assert.That(result.Country, Is.EqualTo(expectedUserModel.Country));
                Assert.That(result.City, Is.EqualTo(expectedUserModel.City));
                Assert.That(result.Address, Is.EqualTo(expectedUserModel.Address));
            }
        }

        [Test]
        public async Task GetAllUsersAsyncReturnsAllUsers()
        {
            var users = new List<AppUser>
                {
                    new AppUser
                    {
                        Id = "1",
                        Email = "user1@example.com",
                        IsAdmin = false,
                        IsReseller = false,
                        CreatedOn = DateTime.UtcNow
                    },
                    new AppUser
                    {
                        Id = "2",
                        Email = "user2@example.com",
                        IsAdmin = true,
                        IsReseller = false,
                        CreatedOn = DateTime.UtcNow
                    },
                    new AppUser
                    {
                        Id = "3",
                        Email = "user3@example.com",
                        IsAdmin = false,
                        IsReseller = true,
                        CreatedOn = DateTime.UtcNow
                    }
                };

            var contextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "DirtXTest")
                .Options;

            using (var context = new ApplicationDbContext(contextOptions))
            {
                context.Users.AddRange(users);
                await context.SaveChangesAsync();
            }

            using (var context = new ApplicationDbContext(contextOptions))
            {
                var userService = new UserService(context);

                var result = await userService.GetAllUsersAsync();

                Assert.That(result, Is.Not.Null);
                Assert.That(result.Count, Is.EqualTo(users.Count));

                foreach (var expectedUser in users)
                {
                    var actualUser = result.FirstOrDefault(u => u.Id == expectedUser.Id);

                    Assert.That(actualUser, Is.Not.Null);
                    Assert.That(actualUser.Email, Is.EqualTo(expectedUser.Email));
                    Assert.That(actualUser.IsAdmin, Is.EqualTo(expectedUser.IsAdmin));
                    Assert.That(actualUser.IsReseller, Is.EqualTo(expectedUser.IsReseller));
                    Assert.That(actualUser.CreatedOn, Is.EqualTo(expectedUser.CreatedOn));
                }
            }
        }

    }
}
