using OllieShop.Catalog.Dtos.ProductDtos;
using OllieShop.Catalog.Entities;

namespace OllieShop.Catalog.Services.ProductServices
{
    public interface IProductService
    {
        Task<List<ResultProductDto>> GetAllProductAsync();
        Task CreateProductAsync(CreateProductDto createProductDto);
        Task UpdateProductAsync(UpdateProductDto updateProductDto);
        Task DeleteProductAsync(string id);
        Task<GetByIdProductDto> GetByIdProductAsync(string id);
        Task<List<ResultProductsWithCategoryDto>> GetProductsWithCategoryAsync();
        Task<ResultAllProductDetailsDto> GetAllProductDetailsAsync(string id);
        Task<List<ResultProductsWithCategoryDto>> GetProductsByCategoryIdAsync(string CategoryId);
        Task<List<Color>> GetColorsForSize(string sizeId,string id);

    }
}
