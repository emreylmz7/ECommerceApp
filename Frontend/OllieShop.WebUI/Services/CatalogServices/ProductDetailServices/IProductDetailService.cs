using OllieShop.DtoLayer.CatalogDtos.ProductDetail;

namespace OllieShop.WebUI.Services.CatalogServices.ProductDetailServices
{
    public interface IProductDetailService
    {
        Task<List<ResultProductDetailDto>> GetAllProductDetailAsync();
        Task<HttpResponseMessage> CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto);
        Task<HttpResponseMessage> UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto);
        Task<HttpResponseMessage> DeleteProductDetailAsync(string id);
        Task<GetByIdProductDetailDto> GetByIdProductDetailAsync(string id);
        Task<UpdateProductDetailDto> GetProductDetailsByProductId(string id);
    }
}
