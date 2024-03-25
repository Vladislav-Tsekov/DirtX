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
                UserName = "Admin",
                Email = "admin@dirtx.com",
                FirstName = "Eli",
                LastName = "Tomac",
                Address = "Center",
                City = "Sofia",
                IsAdmin = true,
                IsReseller = false,
                NormalizedEmail = "admin@dirtx.com",
                NormalizedUserName = "admin"
            };
            admin.PasswordHash = hasher.HashPassword(admin, "AdminUser111");

            AppUser reseller = new()
            {
                UserName = "Reseller",
                Email = "reseller@dirtx.com",
                FirstName = "Ken",
                LastName = "Roczen",
                Address = "Center",
                City = "Plovdiv",
                IsAdmin = false,
                IsReseller = true,
                NormalizedEmail = "reseller@dirtx.com",
                NormalizedUserName = "reseller"
            };
            reseller.PasswordHash = hasher.HashPassword(reseller, "Reseller222");

            AppUser user = new()
            {
                UserName = "User",
                Email = "user@dirtx.com",
                FirstName = "Jett",
                LastName = "Lawrence",
                Address = "Center",
                City = "Ruse",
                IsAdmin = false,
                IsReseller = false,
                NormalizedEmail = "user@dirtx.com",
                NormalizedUserName = "user",
            };
            user.PasswordHash = hasher.HashPassword(user, "NormalUser333");

            admin.Id = Guid.NewGuid().ToString();
            reseller.Id = Guid.NewGuid().ToString();
            user.Id = Guid.NewGuid().ToString();

            string adminRoleId = (await roleManager.FindByNameAsync("Admin")).Id;
            string resellerRoleId = (await roleManager.FindByNameAsync("Reseller")).Id;
            string userRoleId = (await roleManager.FindByNameAsync("User")).Id;

            await userManager.CreateAsync(admin);
            await userManager.AddToRoleAsync(admin, "Admin");
            await userManager.CreateAsync(reseller);
            await userManager.AddToRoleAsync(admin, "Reseller");
            await userManager.CreateAsync(user);
            await userManager.AddToRoleAsync(admin, "User");
        }
    }
}
