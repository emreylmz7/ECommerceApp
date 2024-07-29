using OllieShop.DtoLayer.CatalogDtos.Category;

namespace OllieShop.WebUI.Services.CatalogServices.CategoryServices
{
    public interface ICategoryService
    {
        Task<List<ResultCategoryDto>> GetAllCategoryAsync();
        Task<HttpResponseMessage> CreateCategoryAsync(CreateCategoryDto createCategoryDto);
        Task<HttpResponseMessage> UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto);
        Task<HttpResponseMessage> DeleteCategoryAsync(string id);
        Task<GetByIdCategoryDto> GetByIdCategoryAsync(string id);
    }
}
