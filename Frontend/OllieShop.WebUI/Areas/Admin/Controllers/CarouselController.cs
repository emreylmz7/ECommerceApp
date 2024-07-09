using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OllieShop.DtoLayer.CatalogDtos.Carousel;
using OllieShop.WebUI.Services.ApiServices;

namespace OllieShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    [Route("Admin/Carousel")]
    public class CarouselController : Controller
    {
        private readonly IApiService _apiService;

        public CarouselController(IApiService apiService)
        {
            _apiService = apiService;
        }

        [Route("Index")]    
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var carousels = await _apiService.GetAsync<List<ResultCarouselDto>>("https://localhost:7220/api/Carousels");
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
            var responseMessage = await _apiService.PostAsync("https://localhost:7220/api/Carousels", createCarouselDto);
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
            var responseMessage = await _apiService.DeleteAsync($"https://localhost:7220/api/Carousels?id={id}");
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
            var carousel = await _apiService.GetAsync<UpdateCarouselDto>($"https://localhost:7220/api/Carousels/{id}");
            return View(carousel);
        }

        [HttpPost]
        [Route("UpdateCarousel/{id}")]
        public async Task<IActionResult> UpdateCarousel(UpdateCarouselDto updateCarouselDto)
        {
            var responseMessage = await _apiService.PutAsync("https://localhost:7220/api/Carousels", updateCarouselDto);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Carousel", new { area = "Admin" });
            }
            return View();
        }
    }
}
