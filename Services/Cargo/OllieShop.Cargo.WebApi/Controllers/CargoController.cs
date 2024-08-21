using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OllieShop.Cargo.BusinessLayer.Abstarct;
using OllieShop.Cargo.DtoLayer.Dtos.CargoDtos;
using System.Security.Claims;

namespace OllieShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoController : ControllerBase
    {
        private readonly ICargoService _cargoService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CargoController(ICargoService cargoService, IHttpContextAccessor httpContextAccessor)
        {
            _cargoService = cargoService;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        public async Task<IActionResult> CargoList()
        {
            var values = await _cargoService.TGetAllAsync();

            if (values == null)
            {
                return NotFound();
            }

            var resultCargoDtos = values.Select(value => new ResultCargoDto
            {
                DeliveryDate = value.DeliveryDate,
                DispatchDate = value.DispatchDate,
                Status = value.Status,
                AddressId = value.AddressId,
                CargoId = value.CargoId,
                OrderId = value.OrderId,
                TrackingNumber = value.TrackingNumber,
                UserId = value.UserId
            }).ToList();

            return Ok(resultCargoDtos); 
        }

        [HttpGet("CargoListByUser")]
        public async Task<IActionResult> CargoListByUser()
        {
            var userId = _httpContextAccessor.HttpContext!.User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
            var values = await _cargoService.TGetByFilterAsync(x => x.UserId == userId);

            if (values == null || values.FirstOrDefault()!.UserId != userId)
            {
                return NotFound();
            }

            var resultCargoDtos = values.Select(value => new ResultCargoDto
            {
                DeliveryDate = value.DeliveryDate,
                DispatchDate = value.DispatchDate,
                Status = value.Status,
                AddressId = value.AddressId,
                CargoId = value.CargoId,
                OrderId = value.OrderId,
                TrackingNumber = value.TrackingNumber,
                UserId = value.UserId
            }).ToList();

            return Ok(resultCargoDtos);
        }


        [HttpPost]
        public async Task<IActionResult> CreateCargo(CreateCargoDto createCargoDto)
        {
            await _cargoService.TInsertAsync(
                new EntityLayer.Concrete.Cargo
                {
                    TrackingNumber = createCargoDto.TrackingNumber,
                    OrderId = createCargoDto.OrderId,
                    UserId = createCargoDto.UserId,
                    Status = createCargoDto.Status,
                    DispatchDate = createCargoDto.DispatchDate,
                    DeliveryDate = createCargoDto.DeliveryDate,
                    AddressId = createCargoDto.AddressId
                }
            );
            return Ok("Cargo Created Successfully");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCargo(int id)
        {
            await _cargoService.TDeleteAsync(id);
            return Ok("Cargo Deleted Successfully");
        }

        [HttpGet("user/{id}")]
        public async Task<IActionResult> GetCargoByUser(int id)
        {
            var userId = _httpContextAccessor.HttpContext!.User.FindFirst(ClaimTypes.NameIdentifier)!.Value;

            var value = await _cargoService.TGetByIdAsync(id);

            if (value == null || value.UserId != userId)
            {
                return NotFound();
            }

            var resultCargoDto = new ResultCargoDto
            {
                DeliveryDate = value.DeliveryDate,
                DispatchDate = value.DispatchDate,
                Status = value.Status,
                AddressId = value.AddressId,
                CargoId = value.CargoId,
                OrderId = value.OrderId,
                TrackingNumber = value.TrackingNumber,
                UserId = value.UserId
            };

            return Ok(resultCargoDto);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetCargo(int id)
        {
            var value = await  _cargoService.TGetByIdAsync(id);

            if (value == null)
            {
                return NotFound();
            }

            var resultCargoDto = new ResultCargoDto
            {
                DeliveryDate = value.DeliveryDate,
                DispatchDate = value.DispatchDate,
                Status = value.Status,
                AddressId = value.AddressId,
                CargoId = value.CargoId,
                OrderId = value.OrderId,
                TrackingNumber = value.TrackingNumber,
                UserId = value.UserId
            };

            return Ok(resultCargoDto);
        }


        [HttpPut]
        public async Task<IActionResult> UpdateCargo(UpdateCargoDto updateCargoDto)
        {
            await _cargoService.TUpdateAsync(new EntityLayer.Concrete.Cargo
            {
                CargoId = updateCargoDto.CargoId,
                TrackingNumber = updateCargoDto.TrackingNumber,
                OrderId = updateCargoDto.OrderId,
                UserId = updateCargoDto.UserId,
                Status = updateCargoDto.Status,
                DispatchDate = updateCargoDto.DispatchDate,
                DeliveryDate = updateCargoDto.DeliveryDate,
                AddressId = updateCargoDto.AddressId
            });
            return Ok("Cargo Updated Successfully");
        }
    }
}
