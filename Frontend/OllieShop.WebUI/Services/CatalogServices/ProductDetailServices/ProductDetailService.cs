using OllieShop.DtoLayer.CatalogDtos.ProductDetail;

namespace OllieShop.WebUI.Services.CatalogServices.ProductDetailServices
{
    public class ProductDetailService : IProductDetailService
    {
        private readonly HttpClient _httpClient;

        public ProductDetailService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto)
        {
            var responseMessage = await _httpClient.PostAsJsonAsync<CreateProductDetailDto>("productdetails", createProductDetailDto);
            return responseMessage;
        }

        public async Task<HttpResponseMessage> DeleteProductDetailAsync(string id)
        {
            var responseMessage = await _httpClient.DeleteAsync($"productdetails?id={id}");
            return responseMessage;
        }

        public async Task<List<ResultProductDetailDto>> GetAllProductDetailAsync()
        {
            var responseMessage = await _httpClient.GetAsync("productdetails");
            var productDetails = await responseMessage.Content.ReadFromJsonAsync<List<ResultProductDetailDto>>();
            return productDetails ?? new List<ResultProductDetailDto>();
        }

        public async Task<GetByIdProductDetailDto> GetByIdProductDetailAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync($"productdetails/{id}");
            var productDetail = await responseMessage.Content.ReadFromJsonAsync<GetByIdProductDetailDto>();
            return productDetail;
        }

        public async Task<UpdateProductDetailDto> GetProductDetailsByProductId(string id)
        {
            var responseMessage = await _httpClient.GetAsync($"ProductDetails/GetProductDetailsByProductId?id={id}");
            var productDetail = await responseMessage.Content.ReadFromJsonAsync<UpdateProductDetailDto>();
            return productDetail;
        }

        public async Task<HttpResponseMessage> UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto)
        {
            var responseMessage = await _httpClient.PutAsJsonAsync<UpdateProductDetailDto>("productdetails", updateProductDetailDto);
            return responseMessage;
        }
    }
}
