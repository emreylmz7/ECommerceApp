using OllieShop.DtoLayer.CatalogDtos.Offer;

namespace OllieShop.WebUI.Services.CatalogServices.OfferServices
{
    public interface IOfferService
    {
        Task<List<ResultOfferDto>> GetAllOfferAsync();
        Task<HttpResponseMessage> CreateOfferAsync(CreateOfferDto createOfferDto);
        Task<HttpResponseMessage> UpdateOfferAsync(UpdateOfferDto updateOfferDto);
        Task<HttpResponseMessage> DeleteOfferAsync(string id);
        Task<GetByIdOfferDto> GetByIdOfferAsync(string id);
    }
}
