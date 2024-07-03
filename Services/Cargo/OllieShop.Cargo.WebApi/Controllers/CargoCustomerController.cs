using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OllieShop.Cargo.BusinessLayer.Abstarct;
using OllieShop.Cargo.DtoLayer.Dtos.CargoCustomerDtos;
using OllieShop.Cargo.EntityLayer.Concrete;

namespace OllieShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCustomerController : ControllerBase
    {
        private readonly ICargoCustomerService _customerService;

        public CargoCustomerController(ICargoCustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public IActionResult CargoCustomerList()
        {
            var values = _customerService.TGetAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateCargoCustomer(CreateCargoCustomerDto createCargoCustomerDto)
        {
            _customerService.TInsert(
                new CargoCustomer
                {
                    Name = createCargoCustomerDto.Name,
                    Surname = createCargoCustomerDto.Surname,
                    Email = createCargoCustomerDto.Email,
                    Phone = createCargoCustomerDto.Phone,
                    District = createCargoCustomerDto.District,
                    City = createCargoCustomerDto.City,
                    Address = createCargoCustomerDto.Address
                }
            );
            return Ok("Cargo Customer Created Successfully");
        }

        [HttpDelete]
        public IActionResult DeleteCargoCustomer(int id)
        {
            _customerService.TDelete(id);
            return Ok("Cargo Customer Deleted Successfully");
        }

        [HttpGet("{id}")]
        public IActionResult GetCargoCustomer(int id)
        {
            var value = _customerService.TGetById(id);
            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateCargoCustomer(UpdateCargoCustomerDto updateCargoCustomerDto)
        {
            _customerService.TUpdate(new CargoCustomer
            {
                CargoCustomerId = updateCargoCustomerDto.CargoCustomerId,
                Name = updateCargoCustomerDto.Name,
                Surname = updateCargoCustomerDto.Surname,
                Email = updateCargoCustomerDto.Email,
                Phone = updateCargoCustomerDto.Phone,
                District = updateCargoCustomerDto.District,
                City = updateCargoCustomerDto.City,
                Address = updateCargoCustomerDto.Address
            });
            return Ok("Cargo Customer Updated Successfully");
        }
    }
}
