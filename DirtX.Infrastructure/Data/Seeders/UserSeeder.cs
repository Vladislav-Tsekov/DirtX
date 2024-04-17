using DirtX.Infrastructure.Data.Models.Users;
using Microsoft.AspNetCore.Identity;

namespace DirtX.Infrastructure.Data.Seeders
{
    public class UserSeeder
    {
        public static async Task SeedUsersAsync(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            string[] roles = new[] { "Admin", "User" };

            foreach (string role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    var currentRole = new IdentityRole
                    {
                        Name = role,
                        NormalizedName = role.ToUpper()
                    };

                    await roleManager.CreateAsync(currentRole);
                }
            }

            PasswordHasher<AppUser> hasher = new();

            AppUser admin = new()
            {
                UserName = "admin@dirtx.com",
                Email = "admin@dirtx.com",
                FirstName = "Eli",
                LastName = "Tomac",
                Address = "The Ranch 3",
                City = "Colorado",
                Country = "USA",
                IsAdmin = true,
                IsReseller = false,
                NormalizedEmail = "admin@dirtx.com",
                NormalizedUserName = "admin",
                EmailConfirmed = true
            };
            admin.PasswordHash = hasher.HashPassword(admin, "AdminUser111");

            AppUser user = new()
            {
                UserName = "user@dirtx.com",
                Email = "user@dirtx.com",
                FirstName = "Jett",
                LastName = "Lawrence",
                Address = "7th Avenue",
                City = "New York",
                Country = "USA",
                IsAdmin = false,
                IsReseller = false,
                NormalizedEmail = "user@dirtx.com",
                NormalizedUserName = "user",
                EmailConfirmed = true
            };
            user.PasswordHash = hasher.HashPassword(user, "NormalUser333");

            admin.Id = Guid.NewGuid().ToString();
            user.Id = Guid.NewGuid().ToString();

            await userManager.CreateAsync(admin);
            await userManager.AddToRoleAsync(admin, "Admin");
            await userManager.CreateAsync(user);
            await userManager.AddToRoleAsync(admin, "User");
        }
    }
}
