using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OllieShop.Cargo.BusinessLayer.Abstarct;
using OllieShop.Cargo.DtoLayer.Dtos.CargoDetailDtos;
using OllieShop.Cargo.EntityLayer.Concrete;

namespace OllieShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoDetailController : ControllerBase
    {
        private readonly ICargoDetailService _detailService;

        public CargoDetailController(ICargoDetailService detailService)
        {
            _detailService = detailService;
        }

        [HttpGet]
        public async Task<IActionResult> CargoDetailList()
        {
            var values = await _detailService.TGetAllAsync();
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCargoDetail(CreateCargoDetailDto createCargoDetailDto)
        {
            await _detailService.TInsertAsync(
                new CargoDetail
                {
                    CargoId = createCargoDetailDto.CargoId, // Kargo ID'si
                    ProductName = createCargoDetailDto.ProductName, // Ürün adı
                    Quantity = createCargoDetailDto.Quantity, // Ürün miktarı
                    UnitPrice = createCargoDetailDto.UnitPrice, // Birim fiyat
                    TotalPrice = createCargoDetailDto.TotalPrice // Toplam fiyat
                }
            );
            return Ok("Cargo Detail Created Successfully");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCargoDetail(int id)
        {
            await _detailService.TDeleteAsync(id);
            return Ok("Cargo Detail Deleted Successfully");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCargoDetail(int id)
        {
            var value = await _detailService.TGetByIdAsync(id);
            return Ok(value);
        }

        [HttpGet("DetailsByCargoId/{id}")]
        public async Task<IActionResult> GetCargoDetailsByCargoId(int id)
        {
            var values = await _detailService.TGetByFilterAsync(x => x.CargoId == id);
            return Ok(values);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCargoDetail(UpdateCargoDetailDto updateCargoDetailDto)
        {
            await _detailService.TUpdateAsync(new CargoDetail
            {
                CargoDetailId = updateCargoDetailDto.CargoDetailId, // Kargo detayı ID'si
                CargoId = updateCargoDetailDto.CargoId, // Kargo ID'si
                ProductName = updateCargoDetailDto.ProductName, // Ürün adı
                Quantity = updateCargoDetailDto.Quantity, // Ürün miktarı
                UnitPrice = updateCargoDetailDto.UnitPrice, // Birim fiyat
                TotalPrice = updateCargoDetailDto.TotalPrice // Toplam fiyat
            });
            return Ok("Cargo Detail Updated Successfully");
        }
    }
}
