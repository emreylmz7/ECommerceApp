using OllieShop.DtoLayer.CargoDtos.Cargo;

namespace OllieShop.WebUI.Services.CargoService
{
    public interface ICargoService
    {
        Task<List<ResultCargoDto>> GetAllCargoAsync(); 
        Task<List<ResultCargoDto>> GetAllCargoByUserAsync(); 
        Task<HttpResponseMessage> CreateCargoAsync(CreateCargoDto createCargoDto); 
        Task<HttpResponseMessage> UpdateCargoAsync(UpdateCargoDto updateCargoDto); 
        Task<HttpResponseMessage> DeleteCargoAsync(string id); 
        Task<GetByIdCargoDto> GetByIdCargoAsync(string id);
        Task<GetByIdCargoDto> GetByIdCargoByUserAsync(string id);
        Task<CargoStatisticsDto> GetCargoStatistics();
    }
}
