using DirtX.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;

namespace DirtX.Infrastructure.Data.Seeders
{
    public class UserSeeder
    {
        public async Task SeedUsersAsync(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            string[] roles = new[] { "Admin", "Reseller", "User" };

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

            AppUser reseller = new()
            {
                UserName = "reseller@dirtx.com",
                Email = "reseller@dirtx.com",
                FirstName = "Ken",
                LastName = "Roczen",
                Address = "Downtown",
                City = "Miami",
                Country = "USA",
                IsAdmin = false,
                IsReseller = true,
                NormalizedEmail = "reseller@dirtx.com",
                NormalizedUserName = "reseller",
                EmailConfirmed = true
            };
            reseller.PasswordHash = hasher.HashPassword(reseller, "Reseller222");

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
            reseller.Id = Guid.NewGuid().ToString();
            user.Id = Guid.NewGuid().ToString();

            await userManager.CreateAsync(admin);
            await userManager.AddToRoleAsync(admin, "Admin");
            await userManager.CreateAsync(reseller);
            await userManager.AddToRoleAsync(admin, "Reseller");
            await userManager.CreateAsync(user);
            await userManager.AddToRoleAsync(admin, "User");
        }
    }
}
