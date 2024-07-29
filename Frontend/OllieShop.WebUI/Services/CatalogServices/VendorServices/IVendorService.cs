using OllieShop.DtoLayer.CatalogDtos.Vendor;

namespace OllieShop.WebUI.Services.CatalogServices.VendorServices
{
    public interface IVendorService
    {
        Task<List<ResultVendorDto>> GetAllVendorAsync();
        Task<HttpResponseMessage> CreateVendorAsync(CreateVendorDto createVendorDto);
        Task<HttpResponseMessage> UpdateVendorAsync(UpdateVendorDto updateVendorDto);
        Task<HttpResponseMessage> DeleteVendorAsync(string id);
        Task<GetByIdVendorDto> GetByIdVendorAsync(string id);
    }
}
