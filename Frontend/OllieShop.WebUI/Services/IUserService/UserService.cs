using OllieShop.WebUI.Models;
using System.Net.Http.Json;

namespace OllieShop.WebUI.Services.IUserService
{
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<UserDetailViewModel> GetUserInfoAsync()
        {
            try
            {
                var result = await _httpClient.GetFromJsonAsync<UserDetailViewModel>("/api/user/getUserInfo");
                return result ?? new UserDetailViewModel();
            }
            catch (HttpRequestException ex)
            {
                // Log the exception details here
                // Optionally return a default or empty model if needed
                return new UserDetailViewModel();
            }
        }
    }
}
