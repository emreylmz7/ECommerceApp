using OllieShop.Catalog.Dtos.VendorDtos;

namespace OllieShop.Catalog.Services.VendorServices
{
    public interface IVendorService
    {
        Task<List<ResultVendorDto>> GetAllVendorAsync();
        Task CreateVendorAsync(CreateVendorDto createVendorDto);
        Task UpdateVendorAsync(UpdateVendorDto updateVendorDto);
        Task DeleteVendorAsync(string id);
        Task<GetVendorByIdDto> GetByIdVendorAsync(string id);
    }
}
