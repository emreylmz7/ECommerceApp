using OllieShop.DtoLayer.CatalogDtos.ProductStock;

namespace OllieShop.WebUI.Services.CatalogServices.ProductStockServices
{
    public class ProductStockService : IProductStockService
    {
        private readonly HttpClient _httpClient;

        public ProductStockService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> CreateProductStockAsync(CreateProductStockDto createProductStockDto)
        {
            var responseMessage = await _httpClient.PostAsJsonAsync<CreateProductStockDto>("productstocks", createProductStockDto);
            return responseMessage;
        }

        public async Task<HttpResponseMessage> DeleteProductStockAsync(string id)
        {
            var responseMessage = await _httpClient.DeleteAsync($"productstocks?id={id}");
            return responseMessage;
        }

        public async Task<List<ResultProductStockDto>> GetAllProductStockAsync()
        {
            var responseMessage = await _httpClient.GetAsync("productstocks");
            var productStocks = await responseMessage.Content.ReadFromJsonAsync<List<ResultProductStockDto>>();
            return productStocks ?? new List<ResultProductStockDto>();
        }

        public async Task<GetByIdProductStockDto> GetByIdProductStockAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync($"productstocks/{id}");
            var productStock = await responseMessage.Content.ReadFromJsonAsync<GetByIdProductStockDto>();
            return productStock;
        }

        public async Task<List<GetByIdProductStockDto>> GetProductStocksByProductId(string id)
        {
            var responseMessage = await _httpClient.GetAsync($"ProductStocks/GetProductStocksByProductId/{id}");
            var productStocks = await responseMessage.Content.ReadFromJsonAsync<List<GetByIdProductStockDto>>();
            return productStocks;
        }

        public async Task<ProductStocksStatisticsDto> GetProductStocksStatistics()
        {
            var productStocks = await GetProductStocksWithDetails();
            var totalStock = productStocks.Sum(x => x.Stock);
            var lowStockCount = productStocks.Count(x => x.Stock < 10);
            var outOfStockCount = productStocks.Count(x => x.Stock == 0);
            var maxStockProduct = productStocks.OrderByDescending(x => x.Stock).FirstOrDefault();
            string maxStockProductName = maxStockProduct != null ? maxStockProduct.ProductName : "N/A";
            var totalProductStocks = productStocks.Count();

            var productStocksStatisticsDto = new ProductStocksStatisticsDto
            {
                TotalProductStocks = totalProductStocks,
                TotalStock = totalStock,
                LowStockCount = lowStockCount,
                OutOfStockCount = outOfStockCount,
                MaxStockProductName = maxStockProductName,
            };

            return productStocksStatisticsDto;
        }


        public async Task<List<ResultProductStockWithDetailsDto>> GetProductStocksWithDetails()
        {
            var responseMessage = await _httpClient.GetAsync("productstocks/GetProductStocksWithDetails");
            var productStocks = await responseMessage.Content.ReadFromJsonAsync<List<ResultProductStockWithDetailsDto>>();
            return productStocks ?? new List<ResultProductStockWithDetailsDto>();
        }

        public async Task<HttpResponseMessage> UpdateProductStockAsync(UpdateProductStockDto updateProductStockDto)
        {
            var responseMessage = await _httpClient.PutAsJsonAsync<UpdateProductStockDto>("productstocks", updateProductStockDto);
            return responseMessage;
        }
    }
}
