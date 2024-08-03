using OllieShop.Catalog.Dtos.SizeDtos;

namespace OllieShop.Catalog.Services.SizeServices
{
    public interface ISizeService
    {
        Task<List<ResultSizeDto>> GetAllSizeAsync();
        Task CreateSizeAsync(CreateSizeDto createSizeDto);
        Task UpdateSizeAsync(UpdateSizeDto updateSizeDto);
        Task DeleteSizeAsync(string id);
        Task<GetSizeByIdDto> GetByIdSizeAsync(string id);
    }
}
