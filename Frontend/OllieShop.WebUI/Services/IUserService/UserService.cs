using OllieShop.DtoLayer.IdentityDtos;
using OllieShop.WebUI.Models;

namespace OllieShop.WebUI.Services.IUserService
{
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> AddRoleToUserAsync(AddRoleDto model)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("/api/user/addRoleToUser", model);
                return response.IsSuccessStatusCode;
            }
            catch (HttpRequestException ex)
            {
                // Hata durumunda loglama yapabilirsiniz.
                return false;
            }
        }

        public async Task<bool> ChangePasswordAsync(ChangePasswordDto model)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("/api/user/changePassword", model);
                return response.IsSuccessStatusCode;
            }
            catch (HttpRequestException ex)
            {
                // Hata durumunda loglama yapabilirsiniz.
                return false;
            }
        }

        public async Task<bool> DeleteUserAsync(string id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"/api/user/deleteUser/{id}");
                return response.IsSuccessStatusCode;
            }
            catch (HttpRequestException ex)
            {
                // Hata durumunda loglama yapabilirsiniz.
                return false;
            }
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
                // Hata durumunda loglama yapabilirsiniz.
                return new UserDetailViewModel();
            }
        }

        public async Task<List<UserDetailViewModel>> GetUserListAsync()
        {
            try
            {
                var result = await _httpClient.GetFromJsonAsync<List<UserDetailViewModel>>("/api/user/getUserList");
                return result ?? new List<UserDetailViewModel>();
            }
            catch (HttpRequestException ex)
            {
                // Hata durumunda loglama yapabilirsiniz.
                return new List<UserDetailViewModel>();
            }
        }

        public async Task<bool> UpdateUserAsync(UpdateUserDto model)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync("/api/user/updateUser", model);
                return response.IsSuccessStatusCode;
            }
            catch (HttpRequestException ex)
            {
                // Hata durumunda loglama yapabilirsiniz.
                return false;
            }
        }
    }
}
