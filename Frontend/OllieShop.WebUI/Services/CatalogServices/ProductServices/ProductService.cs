using OllieShop.DtoLayer.CatalogDtos.Color;
using OllieShop.DtoLayer.CatalogDtos.Product;
using OllieShop.DtoLayer.CatalogDtos.ProductStock;

namespace OllieShop.WebUI.Services.CatalogServices.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> CreateProductAsync(CreateProductDto createProductDto)
        {
            var responseMessage = await _httpClient.PostAsJsonAsync<CreateProductDto>("products", createProductDto);
            return responseMessage;
        }

        public async Task<HttpResponseMessage> DeleteProductAsync(string id)
        {
            var responseMessage = await _httpClient.DeleteAsync($"products?id={id}");
            return responseMessage;
        }

        public async Task<List<ResultProductDto>> GetAllProductAsync()
        {
            var responseMessage = await _httpClient.GetAsync("products");
            var products = await responseMessage.Content.ReadFromJsonAsync<List<ResultProductDto>>();
            return products ?? new List<ResultProductDto>();
        }

        public async Task<ResultAllProductDetailsDto> GetAllProductDetailsById(string id)
        {
            var responseMessage = await _httpClient.GetAsync($"Products/GetAllProductDetails?id={id}");
            var product = await responseMessage.Content.ReadFromJsonAsync<ResultAllProductDetailsDto>();
            return product!;
        }

        public async Task<List<ResultProductsWithCategoryDto>> GetAllProductsWithCategoryAsync()
        {
            var responseMessage = await _httpClient.GetAsync("Products/ProductListWithCategory");
            var products = await responseMessage.Content.ReadFromJsonAsync<List<ResultProductsWithCategoryDto>>();
            return products ?? new List<ResultProductsWithCategoryDto>();
        }

        public async Task<List<ResultColorDto>> GetAvailableColorsForSize(string sizeId, string id)
        {
            var responseMessage = await _httpClient.GetAsync($"Products/GetAvailableColorsForSize?sizeId={sizeId}&productId={id}");
            var colors = await responseMessage.Content.ReadFromJsonAsync<List<ResultColorDto>>();
            return colors!;
        }

        public async Task<GetByIdProductDto> GetByIdProductAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync($"products/{id}");
            var product = await responseMessage.Content.ReadFromJsonAsync<GetByIdProductDto>();
            return product;
        }

        public async Task<ProductStatisticsDto> GetProductsStatistics()
        {
            var products = await GetAllProductsWithCategoryAsync();

            var totalProductCount = products.Count();
            var averageProductPrice = products.Average(x => x.Price);
            var mostExpensiveProduct = products.OrderByDescending(x => x.Price).FirstOrDefault();
            var categoryWithMostProducts = products
                .GroupBy(x => x.CategoryName)
                .OrderByDescending(g => g.Count())
                .Select(g => g.Key)
                .FirstOrDefault();

            var productStatistics = new ProductStatisticsDto
            {
                TotalProductCount = totalProductCount,
                AverageProductPrice = averageProductPrice,
                MostExpensiveProductName = mostExpensiveProduct?.Name,
                CategoryWithMostProducts = categoryWithMostProducts
            };

            return productStatistics;
        }


        public async Task<List<ResultProductsWithCategoryDto>> ProductListByCategoryId(string id)
        {
            var responseMessage = await _httpClient.GetAsync($"Products/ProductListByCategory?id={id}");
            var products = await responseMessage.Content.ReadFromJsonAsync<List<ResultProductsWithCategoryDto>>();
            return products;
        }

        public async Task<HttpResponseMessage> UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            var responseMessage = await _httpClient.PutAsJsonAsync<UpdateProductDto>("products", updateProductDto);
            return responseMessage;
        }
    }
}
