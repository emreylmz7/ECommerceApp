using OllieShop.DtoLayer.CargoDtos.CargoDetail;

namespace OllieShop.WebUI.Services.CargoService
{
    public class CargoDetailService : ICargoDetailService
    {
        private readonly HttpClient _httpClient;

        public CargoDetailService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ResultCargoDetailDto>> GetAllCargoDetailsAsync()
        {
            var responseMessage = await _httpClient.GetAsync("cargodetail");
            var cargoDetails = await responseMessage.Content.ReadFromJsonAsync<List<ResultCargoDetailDto>>();
            return cargoDetails ?? new List<ResultCargoDetailDto>();
        }

        public async Task<GetByIdCargoDetailDto> GetCargoDetailByIdAsync(int id)
        {
            var responseMessage = await _httpClient.GetAsync($"cargodetail/{id}");
            var cargoDetail = await responseMessage.Content.ReadFromJsonAsync<GetByIdCargoDetailDto>();
            return cargoDetail;
        }

        public async Task<HttpResponseMessage> CreateCargoDetailAsync(CreateCargoDetailDto createCargoDetailDto)
        {
            var responseMessage = await _httpClient.PostAsJsonAsync("cargodetail", createCargoDetailDto);
            return responseMessage;
        }

        public async Task<HttpResponseMessage> UpdateCargoDetailAsync(UpdateCargoDetailDto updateCargoDetailDto)
        {
            var responseMessage = await _httpClient.PutAsJsonAsync($"cargodetail/{updateCargoDetailDto.CargoDetailId}", updateCargoDetailDto);
            return responseMessage;
        }

        public async Task<HttpResponseMessage> DeleteCargoDetailAsync(int id)
        {
            var responseMessage = await _httpClient.DeleteAsync($"cargodetail/{id}");
            return responseMessage;
        }

        public async Task<List<GetByIdCargoDetailDto>> GetCargoDetailsByCargoIdAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("cargoDetail/DetailsByCargoId/" + id);
            var cargoDetail = await responseMessage.Content.ReadFromJsonAsync<List<GetByIdCargoDetailDto>>();
            return cargoDetail!;
        }
    }
}
