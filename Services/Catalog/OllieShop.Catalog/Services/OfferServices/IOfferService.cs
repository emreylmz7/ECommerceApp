using OllieShop.Catalog.Dtos.OfferDtos;

namespace OllieShop.Catalog.Services.OfferServices
{
    public interface IOfferService
    {
        Task<List<ResultOfferDto>> GetAllOfferAsync();
        Task CreateOfferAsync(CreateOfferDto createOfferDto);
        Task UpdateOfferAsync(UpdateOfferDto updateOfferDto);
        Task DeleteOfferAsync(string id);
        Task<GetOfferByIdDto> GetByIdOfferAsync(string id);
    }
}
