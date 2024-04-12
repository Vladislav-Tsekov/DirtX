using DirtX.Core.Models;
using DirtX.Core.Models.Admin;

namespace DirtX.Core.Interfaces
{
    public interface IUserService
    {
        public Task<ICollection<UserViewModel>> GetAllUsersAsync();
        public Task EditProfileAsync(string userId, EditProfileViewModel model);
        public Task DeleteUserAsync(string userId);
        public Task ToggleUserReseller(string userId);
        public Task ToggleUserAdmin(string userId);
    }
}
