using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OllieShop.Catalog.Dtos.CarouselDtos;
using OllieShop.Catalog.Services.CarouselServices;

namespace OllieShop.Catalog.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class CarouselsController : ControllerBase
    {
        private readonly ICarouselService _carouselService;

        public CarouselsController(ICarouselService carouselService)
        {
            _carouselService = carouselService;
        }

        [HttpGet]
        public async Task<IActionResult> CarouselList()
        {
            var values = await _carouselService.GetAllCarouselAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCarouselById(string id)
        {
            var value = await _carouselService.GetByIdCarouselAsync(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCarousel(CreateCarouselDto createCarouselDto)
        {
            await _carouselService.CreateCarouselAsync(createCarouselDto);
            return Ok("Carousel Added Successfully.");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCarousel(string id)
        {
            await _carouselService.DeleteCarouselAsync(id);
            return Ok("Carousel Deleted Successfully.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCarousel(UpdateCarouselDto updateCarouselDto)
        {
            await _carouselService.UpdateCarouselAsync(updateCarouselDto);
            return Ok("Carousel Updated Successfully.");
        }
    }
}
