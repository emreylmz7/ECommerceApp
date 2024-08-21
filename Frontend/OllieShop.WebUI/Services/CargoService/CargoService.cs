using OllieShop.DtoLayer.CargoDtos.Cargo;
using OllieShop.DtoLayer.Enums;

namespace OllieShop.WebUI.Services.CargoService
{
    public class CargoService : ICargoService
    {
        private readonly HttpClient _httpClient;

        public CargoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> CreateCargoAsync(CreateCargoDto createCargoDto)
        {
            var responseMessage = await _httpClient.PostAsJsonAsync<CreateCargoDto>("cargo", createCargoDto);
            return responseMessage;
        }

        public async Task<HttpResponseMessage> DeleteCargoAsync(string id)
        {
            var responseMessage = await _httpClient.DeleteAsync($"cargo?id={id}");
            return responseMessage;
        }

        public async Task<List<ResultCargoDto>> GetAllCargoAsync()
        {
            var responseMessage = await _httpClient.GetAsync("cargo");
            var cargos = await responseMessage.Content.ReadFromJsonAsync<List<ResultCargoDto>>();
            return cargos ?? new List<ResultCargoDto>();
        }

        public async Task<List<ResultCargoDto>> GetAllCargoByUserAsync()
        {
            var responseMessage = await _httpClient.GetAsync("cargo/CargoListByUser");
            var cargos = await responseMessage.Content.ReadFromJsonAsync<List<ResultCargoDto>>();
            return cargos ?? new List<ResultCargoDto>();
        }

        public async Task<GetByIdCargoDto> GetByIdCargoAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync($"cargo/{id}");
            var cargo = await responseMessage.Content.ReadFromJsonAsync<GetByIdCargoDto>();
            return cargo;
        }

        public async Task<GetByIdCargoDto> GetByIdCargoByUserAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync($"cargo/user/{id}");
            var cargo = await responseMessage.Content.ReadFromJsonAsync<GetByIdCargoDto>();
            return cargo;
        }

        public async Task<CargoStatisticsDto> GetCargoStatistics()
        {
            var cargos = await GetAllCargoAsync();

            var totalCargoCount = cargos.Count;
            var deliveredCargoCount = cargos.Count(x => x.Status == CargoStatus.Delivered);
            var pendingDeliveryCargoCount = cargos.Count(x => x.Status == CargoStatus.Dispatched);
            var cargosDispatchedInLast30Days = cargos.Count(x => x.DispatchDate >= DateTime.Now.AddDays(-30));

            var cargoStatisticsDto = new CargoStatisticsDto
            {
                TotalCargoCount = totalCargoCount,
                DeliveredCargoCount = deliveredCargoCount,
                PendingDeliveryCargoCount = pendingDeliveryCargoCount,
                CargosDispatchedInLast30Days = cargosDispatchedInLast30Days
            };

            return cargoStatisticsDto;
        }


        public async Task<HttpResponseMessage> UpdateCargoAsync(UpdateCargoDto updateCargoDto)
        {
            var responseMessage = await _httpClient.PutAsJsonAsync<UpdateCargoDto>("cargo", updateCargoDto);
            return responseMessage;
        }
    }
}
