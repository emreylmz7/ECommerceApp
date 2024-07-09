namespace OllieShop.WebUI.Services.ApiServices
{
    public interface IApiService
    {
        Task<T> GetAsync<T>(string url);
        Task<HttpResponseMessage> PostAsync<T>(string url, T data);
        Task<HttpResponseMessage> PutAsync<T>(string url, T data);
        Task<HttpResponseMessage> DeleteAsync(string url);
    }
}
