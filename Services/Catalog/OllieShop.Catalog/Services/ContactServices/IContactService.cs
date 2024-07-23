using OllieShop.Catalog.Dtos.ContactDtos;

namespace OllieShop.Catalog.Services.ContactServices
{
    public interface IContactService
    {
        Task<List<ResultContactDto>> GetAllContactAsync();
        Task CreateContactAsync(CreateContactDto createContactDto);
        Task UpdateContactAsync(UpdateContactDto updateContactDto);
        Task DeleteContactAsync(string id);
        Task<GetContactByIdDto> GetByIdContactAsync(string id);
    }
}
