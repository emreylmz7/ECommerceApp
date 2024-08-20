using OllieShop.DtoLayer.CatalogDtos.Color;
using OllieShop.DtoLayer.CatalogDtos.Product;
using OllieShop.DtoLayer.CatalogDtos.ProductStock;

namespace OllieShop.WebUI.Services.CatalogServices.ProductServices
{
    public interface IProductService
    {
        Task<List<ResultProductDto>> GetAllProductAsync();
        Task<List<ResultProductsWithCategoryDto>> GetAllProductsWithCategoryAsync();
        Task<HttpResponseMessage> CreateProductAsync(CreateProductDto createProductDto);
        Task<HttpResponseMessage> UpdateProductAsync(UpdateProductDto updateProductDto);
        Task<HttpResponseMessage> DeleteProductAsync(string id);
        Task<GetByIdProductDto> GetByIdProductAsync(string id);
        Task<List<ResultProductsWithCategoryDto>> ProductListByCategoryId(string id);
        Task<ResultAllProductDetailsDto> GetAllProductDetailsById(string id);
        Task<List<ResultColorDto>> GetAvailableColorsForSize(string sizeId, string id);
        Task<ProductStatisticsDto> GetProductsStatistics();
    }
}
