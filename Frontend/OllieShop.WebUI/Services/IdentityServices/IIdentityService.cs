using OllieShop.DtoLayer.IdentityDtos;
using OllieShop.WebUI.Settings;

namespace OllieShop.WebUI.Services.IdentityServices
{
    public interface IIdentityService
    {
        Task<bool> SignIn(LoginDto loginDto);
        Task<bool> GetRefreshToken();
    }
}
