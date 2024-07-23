using OllieShop.WebUI.Models;

namespace OllieShop.WebUI.Services.IUserService
{
    public interface IUserService
    {
        Task<UserDetailViewModel> GetUserInfoAsync();
    }
}
