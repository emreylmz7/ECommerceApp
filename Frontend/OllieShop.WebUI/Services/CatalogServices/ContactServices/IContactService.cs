using OllieShop.DtoLayer.CatalogDtos.Contact;

namespace OllieShop.WebUI.Services.CatalogServices.ContactServices
{
    public interface IContactService
    {
        Task<List<ResultContactDto>> GetAllContactAsync();
        Task<HttpResponseMessage> CreateContactAsync(CreateContactDto createContactDto);
        Task<HttpResponseMessage> UpdateContactAsync(UpdateContactDto updateContactDto);
        Task<HttpResponseMessage> DeleteContactAsync(string id);
        Task<GetByIdContactDto> GetByIdContactAsync(string id);
    }
}
