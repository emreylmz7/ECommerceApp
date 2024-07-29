using Microsoft.AspNetCore.Mvc;
using OllieShop.DtoLayer.CatalogDtos.Carousel;
using OllieShop.WebUI.Services.CatalogServices.CarouselServices;

namespace OllieShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Carousel")]
    public class CarouselController : Controller
    {
        private readonly ICarouselService _carouselService;

        public CarouselController(ICarouselService carouselService)
        {
            _carouselService = carouselService;
        }

        [Route("Index")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var carousels = await _carouselService.GetAllCarouselAsync();
            return View(carousels);
        }

        [Route("CreateCarousel")]
        [HttpGet]
        public IActionResult CreateCarousel()
        {
            return View();
        }

        [HttpPost]
        [Route("CreateCarousel")]
        public async Task<IActionResult> CreateCarousel(CreateCarouselDto createCarouselDto)
        {
            var responseMessage = await _carouselService.CreateCarouselAsync(createCarouselDto);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Carousel", new { area = "Admin" });
            }
            return View();
        }

        [Route("DeleteCarousel/{id}")]
        [HttpGet]
        public async Task<IActionResult> DeleteCarousel(string id)
        {
            var responseMessage = await _carouselService.DeleteCarouselAsync(id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Carousel", new { area = "Admin" });
            }
            return View();
        }

        [Route("UpdateCarousel/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateCarousel(string id)
        {
            var carousel = await _carouselService.GetByIdCarouselAsync(id);
            var updateCarouselDto = new UpdateCarouselDto
            {
                CarouselId = carousel.CarouselId,
                ImageUrl = carousel.ImageUrl,
                Status = carousel.Status,
                Title = carousel.Title,
                Description = carousel.Description, 
            };
            return View(updateCarouselDto);
        }

        [HttpPost]
        [Route("UpdateCarousel/{id}")]
        public async Task<IActionResult> UpdateCarousel(UpdateCarouselDto updateCarouselDto)
        {
            var responseMessage = await _carouselService.UpdateCarouselAsync(updateCarouselDto);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Carousel", new { area = "Admin" });
            }
            return View();
        }
    }
}
