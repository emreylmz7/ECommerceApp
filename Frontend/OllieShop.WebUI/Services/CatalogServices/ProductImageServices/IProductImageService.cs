using OllieShop.DtoLayer.CatalogDtos.ProductImage;

namespace OllieShop.WebUI.Services.CatalogServices.ProductImageServices
{
    public interface IProductImageService
    {
        Task<List<ResultProductImageDto>> GetAllProductImageAsync();
        Task<HttpResponseMessage> CreateProductImageAsync(CreateProductImageDto createProductImageDto);
        Task<HttpResponseMessage> UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto);
        Task<HttpResponseMessage> DeleteProductImageAsync(string id);
        Task<GetByIdProductImageDto> GetByIdProductImageAsync(string id);
        Task<UpdateProductImageDto> GetProductImagesByProductId(string id);
    }
}
