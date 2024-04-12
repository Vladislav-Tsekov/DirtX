﻿using DirtX.Core.Models;
using DirtX.Core.Models.Admin;

namespace DirtX.Core.Interfaces
{
    public interface IUserService
    {
        public Task<ICollection<UserViewModel>> GetAllUsersAsync();
        public Task EditProfileAsync(string userId, EditProfileViewModel model);
        public Task DeleteUserAsync(string userId);
        public Task PromoteUserToReseller(string userId);
        public Task PromoteUserToAdmin(string userId);
        public Task DemoteUser(string userId);
    }
}