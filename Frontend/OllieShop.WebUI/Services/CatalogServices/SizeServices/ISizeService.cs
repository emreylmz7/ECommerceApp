using OllieShop.DtoLayer.CatalogDtos.Size;

namespace OllieShop.WebUI.Services.CatalogServices.SizeServices
{
    public interface ISizeService
    {
        Task<List<ResultSizeDto>> GetAllSizeAsync();
        Task<HttpResponseMessage> CreateSizeAsync(CreateSizeDto createSizeDto);
        Task<HttpResponseMessage> UpdateSizeAsync(UpdateSizeDto updateSizeDto);
        Task<HttpResponseMessage> DeleteSizeAsync(string id);
        Task<GetByIdSizeDto> GetByIdSizeAsync(string id);
    }
}
