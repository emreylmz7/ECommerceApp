using OllieShop.DtoLayer.CatalogDtos.ProductImage;
using System.Net.Http.Json;

namespace OllieShop.WebUI.Services.CatalogServices.ProductImageServices
{
    public class ProductImageService : IProductImageService
    {
        private readonly HttpClient _httpClient;

        public ProductImageService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> CreateProductImageAsync(CreateProductImageDto createProductImageDto)
        {
            var responseMessage = await _httpClient.PostAsJsonAsync<CreateProductImageDto>("productimages", createProductImageDto);
            return responseMessage;
        }

        public async Task<HttpResponseMessage> DeleteProductImageAsync(string id)
        {
            var responseMessage = await _httpClient.DeleteAsync($"productimages?id={id}");
            return responseMessage;
        }

        public async Task<List<ResultProductImageDto>> GetAllProductImageAsync()
        {
            var responseMessage = await _httpClient.GetAsync("productimages");
            var productImages = await responseMessage.Content.ReadFromJsonAsync<List<ResultProductImageDto>>();
            return productImages ?? new List<ResultProductImageDto>();
        }

        public async Task<GetByIdProductImageDto> GetByIdProductImageAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync($"productimages/{id}");
            var productImage = await responseMessage.Content.ReadFromJsonAsync<GetByIdProductImageDto>();
            return productImage;
        }

        public async Task<UpdateProductImageDto> GetProductImagesByProductId(string id)
        {
            var responseMessage = await _httpClient.GetAsync($"ProductImages/GetImagesByProductId?id={id}");
            var productImage = await responseMessage.Content.ReadFromJsonAsync<UpdateProductImageDto>();
            return productImage;
        }

        public async Task<HttpResponseMessage> UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto)
        {
            var responseMessage = await _httpClient.PutAsJsonAsync<UpdateProductImageDto>("productimages", updateProductImageDto);
            return responseMessage;
        }
    }
}
