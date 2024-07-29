using OllieShop.DtoLayer.CatalogDtos.Category;
using System.Net.Http.Json;

namespace OllieShop.WebUI.Services.CatalogServices.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _httpClient;

        public CategoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> CreateCategoryAsync(CreateCategoryDto createCategoryDto)
        {
            var responseMessage = await _httpClient.PostAsJsonAsync<CreateCategoryDto>("categories", createCategoryDto);
            return responseMessage;
        }

        public async Task<HttpResponseMessage> DeleteCategoryAsync(string id)
        {
            var responseMessage = await _httpClient.DeleteAsync($"categories?id={id}");
            return responseMessage;
        }

        public async Task<List<ResultCategoryDto>> GetAllCategoryAsync()
        {
            var responseMessage = await _httpClient.GetAsync("categories");
            var categories = await responseMessage.Content.ReadFromJsonAsync<List<ResultCategoryDto>>();
            return categories ?? new List<ResultCategoryDto>();
        }

        public async Task<GetByIdCategoryDto> GetByIdCategoryAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync($"categories/{id}");
            var category = await responseMessage.Content.ReadFromJsonAsync<GetByIdCategoryDto>();
            return category;
        }

        public async Task<HttpResponseMessage> UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
        {
            var responseMessage = await _httpClient.PutAsJsonAsync<UpdateCategoryDto>("categories", updateCategoryDto);
            return responseMessage;
        }
    }
}
