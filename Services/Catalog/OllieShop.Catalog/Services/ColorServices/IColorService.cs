using OllieShop.Catalog.Dtos.ColorDtos;

namespace OllieShop.Catalog.Services.ColorServices
{
    public interface IColorService
    {
        Task<List<ResultColorDto>> GetAllColorAsync();
        Task CreateColorAsync(CreateColorDto createColorDto);
        Task UpdateColorAsync(UpdateColorDto updateColorDto);
        Task DeleteColorAsync(string id);
        Task<GetColorByIdDto> GetByIdColorAsync(string id);
    }
}
