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
        public IActionResult CargoDetailList()
        {
            var values = _detailService.TGetAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateCargoDetail(CreateCargoDetailDto createCargoDetailDto)
        {
            _detailService.TInsert(
                new CargoDetail
                {
                    SenderCustomer = createCargoDetailDto.SenderCustomer,
                    ReceiverCustomer = createCargoDetailDto.ReceiverCustomer,
                    Barcode = createCargoDetailDto.Barcode,
                    CargoCompanyId = createCargoDetailDto.CargoCompanyId
                }
            );
            return Ok("Cargo Detail Created Successfully");
        }

        [HttpDelete]
        public IActionResult DeleteCargoDetail(int id)
        {
            _detailService.TDelete(id);
            return Ok("Cargo Detail Deleted Successfully");
        }

        [HttpGet("{id}")]
        public IActionResult GetCargoDetail(int id)
        {
            var value = _detailService.TGetById(id);
            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateCargoDetail(UpdateCargoDetailDto updateCargoDetailDto)
        {
            _detailService.TUpdate(new CargoDetail
            {
                CargoDetailId = updateCargoDetailDto.CargoDetailId,
                SenderCustomer = updateCargoDetailDto.SenderCustomer,
                ReceiverCustomer = updateCargoDetailDto.ReceiverCustomer,
                Barcode = updateCargoDetailDto.Barcode,
                CargoCompanyId = updateCargoDetailDto.CargoCompanyId
            });
            return Ok("Cargo Detail Updated Successfully");
        }
    }
}
