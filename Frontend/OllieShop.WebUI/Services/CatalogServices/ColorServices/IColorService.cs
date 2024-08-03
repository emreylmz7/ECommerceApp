using OllieShop.DtoLayer.CatalogDtos.Color;

namespace OllieShop.WebUI.Services.CatalogServices.ColorServices
{
    public interface IColorService
    {
        Task<List<ResultColorDto>> GetAllColorAsync();
        Task<HttpResponseMessage> CreateColorAsync(CreateColorDto createColorDto);
        Task<HttpResponseMessage> UpdateColorAsync(UpdateColorDto updateColorDto);
        Task<HttpResponseMessage> DeleteColorAsync(string id);
        Task<GetByIdColorDto> GetByIdColorAsync(string id);
    }
}
