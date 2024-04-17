using DirtX.Core.Interfaces;
using DirtX.Core.Models;
using DirtX.Core.Models.Admin;
using DirtX.Infrastructure.Data;
using DirtX.Infrastructure.Data.Models.Users;
using Microsoft.EntityFrameworkCore;

namespace DirtX.Core.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext context;

        public UserService(ApplicationDbContext _context)
        {
            context = _context;
        }

        public async Task<List<UserViewModel>> GetAllUsersAsync()
        {
            return await context.Users
                .Select(u => new UserViewModel()
                {
                    Id = u.Id.ToString(),
                    Username = u.UserName,
                    IsAdmin = u.IsAdmin,
                    IsReseller = u.IsReseller,
                    CreatedOn = u.CreatedOn
                })
                .ToListAsync();
        }

        public async Task EditProfileAsync(string userId, EditProfileViewModel model)
        {
            AppUser user = await context.Users
                .Where(u => u.Id.ToString() == userId)
                .FirstAsync();

            if (user != null)
            {
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.Country = model.Country;
                user.City = model.City;
                user.Address = model.Address;
                user.ProfilePicture = model.ProfilePicture;
                user.Email = model.Email;

                await context.SaveChangesAsync();
            }
        }

        public Task DeleteUserAsync(string userId)
        {
            AppUser user = context.Users
                .Where(u => u.Id.ToString() == userId)
                .First();

            //TODO - CHECK AGAIN IC CASE OF ERRORS, DELETE RELATED TABLES LIKE GARAGE TOO.

            context.Users.Remove(user);
            context.SaveChangesAsync();

            return Task.CompletedTask;
        }

        public async Task ToggleUserReseller(string userId)
        {
            AppUser user = await context.Users
                .Where(u => u.Id.ToString() == userId)
                .FirstAsync();

            if (user.IsReseller is true)
                user.IsReseller = false;
            else
                user.IsReseller = true;

            await context.SaveChangesAsync();
        }

        public async Task ToggleUserAdmin(string userId)
        {
            AppUser user = await context.Users
                .Where(u => u.Id.ToString() == userId)
                .FirstAsync();

            if (user.IsAdmin is true)
                user.IsAdmin = false;
            else
                user.IsAdmin = true;

            await context.SaveChangesAsync();
        }
    }
}
