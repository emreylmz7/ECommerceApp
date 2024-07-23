using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace OllieShop.WebUI.Services.ApiServices
{
    public class ApiService : IApiService
    {
        private readonly HttpClient _client;

        public ApiService(HttpClient client)
        {
            _client = client;
        }

        public async Task<T> GetAsync<T>(string url)
        {
            var responseMessage = await _client.GetAsync(url);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(jsonData)!;
            }
            return default(T)!;
        }

        public async Task<HttpResponseMessage> PostAsync<T>(string url, T data)
        {
            var jsonData = JsonConvert.SerializeObject(data);
            var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            return await _client.PostAsync(url, stringContent);
        }

        public async Task<HttpResponseMessage> PutAsync<T>(string url, T data)
        {
            var jsonData = JsonConvert.SerializeObject(data);
            var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            return await _client.PutAsync(url, stringContent);
        }

        public async Task<HttpResponseMessage> DeleteAsync(string url)
        {
            return await _client.DeleteAsync(url);
        }

        public async Task<T> GetWithTokenAsync<T>(string url, string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",token);
            var responseMessage = await _client.GetAsync(url);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(jsonData)!;
            }
            return default(T)!;
        }
    }
}
