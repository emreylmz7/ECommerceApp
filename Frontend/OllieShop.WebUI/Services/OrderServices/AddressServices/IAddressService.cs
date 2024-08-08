using OllieShop.DtoLayer.OrderDtos.Address;

namespace OllieShop.WebUI.Services.OrderServices.AddressServices
{
    public interface IAddressService
    {
        Task<List<ResultAddressDto>> GetAllAddressAsync();
        Task<HttpResponseMessage> CreateAddressAsync(CreateAddressDto createAddressDto);
        Task<HttpResponseMessage> UpdateAddressAsync(UpdateAddressDto updateAddressDto);
        Task<HttpResponseMessage> DeleteAddressAsync(string id);
        Task<GetByIdAddressDto> GetByIdAddressAsync(string id);
    }
}
