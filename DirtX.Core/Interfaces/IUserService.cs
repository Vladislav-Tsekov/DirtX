using DirtX.Core.Models;

namespace DirtX.Core.Interfaces
{
    public interface IUserService
    {
        Task<List<UserViewModel>> GetAllUsersAsync();
        Task<List<UserViewModel>> GetAllUsersWithoutCurrentAsync(string userId);
        Task EditProfileAsync(string userId, EditProfileViewModel model);
        Task DeleteUser(string userId);
        Task ToggleUserAdmin(string userId);
        Task<EditProfileViewModel> GetUserByIdAsync(string userId);
    }
}
