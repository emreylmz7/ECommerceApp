using OllieShop.DtoLayer.CargoDtos.CargoDetail;

namespace OllieShop.WebUI.Services.CargoService
{
    public interface ICargoDetailService
    {
        Task<List<ResultCargoDetailDto>> GetAllCargoDetailsAsync(); 
        Task<GetByIdCargoDetailDto> GetCargoDetailByIdAsync(int id); 
        Task<List<GetByIdCargoDetailDto>> GetCargoDetailsByCargoIdAsync(string id); 
        Task<HttpResponseMessage> CreateCargoDetailAsync(CreateCargoDetailDto createCargoDetailDto); 
        Task<HttpResponseMessage> UpdateCargoDetailAsync(UpdateCargoDetailDto updateCargoDetailDto);
        Task<HttpResponseMessage> DeleteCargoDetailAsync(int id); 
    }
}
