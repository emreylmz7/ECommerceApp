using OllieShop.DtoLayer.CatalogDtos.Product;

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
    }
}
