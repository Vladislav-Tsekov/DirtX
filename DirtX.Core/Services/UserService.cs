using DirtX.Core.Interfaces;
using DirtX.Core.Models;
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

        public async Task<EditProfileViewModel> GetUserByIdAsync(string userId)
        {
            if (!Guid.TryParse(userId, out Guid parsedUserId))
            {
                return null;
            }

            EditProfileViewModel userModel = await context.Users
                .Where(u => u.Id == parsedUserId.ToString())
                .Select(u => new EditProfileViewModel()
                {
                    Id = u.Id.ToString(),
                    Email = u.Email,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Country = u.Country,
                    City = u.City,
                    Address = u.Address,
                })
                .FirstOrDefaultAsync();

            return userModel;
        }

        public async Task<List<UserViewModel>> GetAllUsersAsync()
        {
            return await context.Users
                .Select(u => new UserViewModel()
                {
                    Id = u.Id.ToString(),
                    Email = u.Email,
                    IsAdmin = u.IsAdmin,
                    IsReseller = u.IsReseller,
                    CreatedOn = u.CreatedOn
                })
                .ToListAsync();
        }

        public async Task<List<UserViewModel>> GetAllUsersWithoutCurrentAsync(string userId)
        {
            if (!Guid.TryParse(userId, out Guid parsedUserId))
            {
                return null;
            }

            List<UserViewModel> allUsers = await context.Users
                .Where(u => u.Id != parsedUserId.ToString())
                .Select(u => new UserViewModel()
                {
                    Id = u.Id.ToString(),
                    Email = u.Email,
                    IsAdmin = u.IsAdmin,
                    CreatedOn = u.CreatedOn,
                })
                .ToListAsync();

            return allUsers;
        }

        public async Task EditProfileAsync(string userId, EditProfileViewModel model)
        {
            if (!Guid.TryParse(userId, out Guid parsedUserId))
            {
                return;
            }

            AppUser user = await context.Users
                .Where(u => u.Id == parsedUserId.ToString())
                .FirstOrDefaultAsync();

            if (user != null)
            {
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.Country = model.Country;
                user.City = model.City;
                user.Address = model.Address;
                user.Email = model.Email;

                await context.SaveChangesAsync();
            }
        }

        public Task DeleteUser(string userId)
        {
            if (!Guid.TryParse(userId, out Guid parsedUserId))
            {
                Exception ex = new("User not found!");
                return Task.FromException(ex);
            }

            AppUser user = context.Users
                .Where(u => u.Id == parsedUserId.ToString())
                .First();

            context.Users.Remove(user);
            context.SaveChanges();

            return Task.CompletedTask;
        }

        public async Task ToggleUserAdmin(string userId)
        {
            if (!Guid.TryParse(userId, out Guid parsedUserId))
            {
                return;
            }

            AppUser user = await context.Users
                .Where(u => u.Id == parsedUserId.ToString())
                .FirstAsync();

            user.IsAdmin = !user.IsAdmin;

            await context.SaveChangesAsync();
        }
    }
}
