using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OllieShop.Cargo.BusinessLayer.Abstarct;
using OllieShop.Cargo.DtoLayer.Dtos.CargoCompanyDtos;
using OllieShop.Cargo.EntityLayer.Concrete;

namespace OllieShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCompanyController : ControllerBase
    {
        private readonly ICargoCompanyService _companyService;

        public CargoCompanyController(ICargoCompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet]
        public IActionResult CargoCompanyList() 
        {
            var values = _companyService.TGetAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateCargoCompany(CreateCargoCompanyDto createCargoCompanyDto)
        {
            _companyService.TInsert(
                new CargoCompany{
                    CargoCompanyName = createCargoCompanyDto.CargoCompanyName                
                }
            );
            return Ok("Cargo Company Created Successfully");
        }

        [HttpDelete]
        public IActionResult DeleteCargoCompany(int id)
        {
            _companyService.TDelete(id);
            return Ok("Cargo Company Deleted Successfully");
        }

        [HttpGet("id")]
        public IActionResult GetCargoCompany(int id)
        {
            var value = _companyService.TGetById(id);
            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateCargoCompany(UpdateCargoCompanyDto updateCargoCompanyDto)
        {
            _companyService.TUpdate(new CargoCompany
            {
                CargoCompanyId = updateCargoCompanyDto.CargoCompanyId,
                CargoCompanyName = updateCargoCompanyDto.CargoCompanyName
            });
            return Ok("Cargo Company Updated Successfully");
        }
    }
}
