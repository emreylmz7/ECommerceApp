using OllieShop.DtoLayer.CatalogDtos.About;

namespace OllieShop.WebUI.Services.CatalogServices.AboutServices
{
    public interface IAboutService
    {
        Task<List<ResultAboutDto>> GetAllAboutAsync();
        Task<HttpResponseMessage> CreateAboutAsync(CreateAboutDto createAboutDto);
        Task<HttpResponseMessage> UpdateAboutAsync(UpdateAboutDto updateAboutDto);
        Task<HttpResponseMessage> DeleteAboutAsync(string id);
        Task<GetByIdAboutDto> GetByIdAboutAsync(string id);
    }
}
