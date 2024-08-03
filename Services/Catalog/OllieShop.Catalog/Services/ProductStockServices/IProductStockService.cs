using OllieShop.Catalog.Dtos.ProductStockDtos;

namespace OllieShop.Catalog.Services.ProductStockServices
{
    public interface IProductStockService
    {
        Task<List<ResultProductStockDto>> GetAllProductStockAsync();
        Task CreateProductStockAsync(CreateProductStockDto createProductStockDto);
        Task UpdateProductStockAsync(UpdateProductStockDto updateProductStockDto);
        Task DeleteProductStockAsync(string id);
        Task<GetProductStockByIdDto> GetByIdProductStockAsync(string id);
        Task<List<GetProductStockByIdDto>> GetProductStocksByProductId(string productId);
        Task<List<ResultProductStockWithDetailsDto>> GetProductStocksWithDetails();
    }
}
