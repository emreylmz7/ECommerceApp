using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OllieShop.Cargo.BusinessLayer.Abstarct;
using OllieShop.Cargo.DtoLayer.Dtos.CargoOperationDtos;
using OllieShop.Cargo.EntityLayer.Concrete;

namespace OllieShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoOperationController : ControllerBase
    {
        private readonly ICargoOperationService _operationService;

        public CargoOperationController(ICargoOperationService operationService)
        {
            _operationService = operationService;
        }

        [HttpGet]
        public IActionResult CargoOperationList()
        {
            var values = _operationService.TGetAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateCargoOperation(CreateCargoOperationDto createCargoOperationDto)
        {
            _operationService.TInsert(
                new CargoOperation
                {
                    Barcode = createCargoOperationDto.Barcode,
                    Description = createCargoOperationDto.Description,
                    OperationDate = createCargoOperationDto.OperationDate
                }
            );
            return Ok("Cargo Operation Created Successfully");
        }

        [HttpDelete]
        public IActionResult DeleteCargoOperation(int id)
        {
            _operationService.TDelete(id);
            return Ok("Cargo Operation Deleted Successfully");
        }

        [HttpGet("{id}")]
        public IActionResult GetCargoOperation(int id)
        {
            var value = _operationService.TGetById(id);
            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateCargoOperation(UpdateCargoOperationDto updateCargoOperationDto)
        {
            _operationService.TUpdate(new CargoOperation
            {
                CargoOperationId = updateCargoOperationDto.CargoOperationId,
                Barcode = updateCargoOperationDto.Barcode,
                Description = updateCargoOperationDto.Description,
                OperationDate = updateCargoOperationDto.OperationDate
            });
            return Ok("Cargo Operation Updated Successfully");
        }
    }
}
