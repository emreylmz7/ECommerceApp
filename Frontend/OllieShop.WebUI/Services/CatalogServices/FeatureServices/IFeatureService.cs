using OllieShop.DtoLayer.CatalogDtos.Feature;

namespace OllieShop.WebUI.Services.CatalogServices.FeatureServices
{
    public interface IFeatureService
    {
        Task<List<ResultFeatureDto>> GetAllFeatureAsync();
        Task<HttpResponseMessage> CreateFeatureAsync(CreateFeatureDto createFeatureDto);
        Task<HttpResponseMessage> UpdateFeatureAsync(UpdateFeatureDto updateFeatureDto);
        Task<HttpResponseMessage> DeleteFeatureAsync(string id);
        Task<GetByIdFeatureDto> GetByIdFeatureAsync(string id);
    }
}
