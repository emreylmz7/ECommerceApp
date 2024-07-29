using OllieShop.DtoLayer.CatalogDtos.Vendor;

namespace OllieShop.WebUI.Services.CatalogServices.VendorServices
{
    public class VendorService : IVendorService
    {
        private readonly HttpClient _httpClient;

        public VendorService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> CreateVendorAsync(CreateVendorDto createVendorDto)
        {
            var responseMessage = await _httpClient.PostAsJsonAsync<CreateVendorDto>("vendors", createVendorDto);
            return responseMessage;
        }

        public async Task<HttpResponseMessage> DeleteVendorAsync(string id)
        {
            var responseMessage = await _httpClient.DeleteAsync($"vendors?id={id}");
            return responseMessage;
        }

        public async Task<List<ResultVendorDto>> GetAllVendorAsync()
        {
            var responseMessage = await _httpClient.GetAsync("vendors");
            var vendors = await responseMessage.Content.ReadFromJsonAsync<List<ResultVendorDto>>();
            return vendors ?? new List<ResultVendorDto>();
        }

        public async Task<GetByIdVendorDto> GetByIdVendorAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync($"vendors/{id}");
            var vendor = await responseMessage.Content.ReadFromJsonAsync<GetByIdVendorDto>();
            return vendor;
        }

        public async Task<HttpResponseMessage> UpdateVendorAsync(UpdateVendorDto updateVendorDto)
        {
            var responseMessage = await _httpClient.PutAsJsonAsync<UpdateVendorDto>("vendors", updateVendorDto);
            return responseMessage;
        }
    }
}
