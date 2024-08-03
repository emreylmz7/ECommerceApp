using OllieShop.DtoLayer.CatalogDtos.ProductStock;

namespace OllieShop.WebUI.Services.CatalogServices.ProductStockServices
{
    public interface IProductStockService
    {
        Task<List<ResultProductStockDto>> GetAllProductStockAsync();
        Task<HttpResponseMessage> CreateProductStockAsync(CreateProductStockDto createProductStockDto);
        Task<HttpResponseMessage> UpdateProductStockAsync(UpdateProductStockDto updateProductStockDto);
        Task<HttpResponseMessage> DeleteProductStockAsync(string id);
        Task<GetByIdProductStockDto> GetByIdProductStockAsync(string id);
        Task<UpdateProductStockDto> GetProductStocksByProductId(string id);
        Task<List<ResultProductStockWithDetailsDto>> GetProductStocksWithDetails();

    }
}
