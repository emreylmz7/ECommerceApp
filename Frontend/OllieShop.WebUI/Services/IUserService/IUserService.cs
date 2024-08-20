using OllieShop.DtoLayer.IdentityDtos;
using OllieShop.WebUI.Models;

namespace OllieShop.WebUI.Services.IUserService
{
    public interface IUserService
    {
        Task<UserDetailViewModel> GetUserInfoAsync();
        Task<List<UserDetailViewModel>> GetUserListAsync();
        Task<bool> UpdateUserAsync(UpdateUserDto model);
        Task<bool> DeleteUserAsync(string id);
        Task<bool> AddRoleToUserAsync(AddRoleDto model);
        Task<bool> ChangePasswordAsync(ChangePasswordDto model);
        Task<UserStatisticsDto> GetUsersStatistics();
    }
}
