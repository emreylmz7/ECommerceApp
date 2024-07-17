using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OllieShop.DtoLayer.CatalogDtos.About;
using OllieShop.WebUI.Services.ApiServices;

namespace OllieShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    [Route("Admin/About")]
    public class AboutController : Controller
    {
        private readonly IApiService _apiService;

        public AboutController(IApiService apiService)
        {
            _apiService = apiService;
        }

        [Route("Index")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var abouts = await _apiService.GetAsync<List<ResultAboutDto>>("https://localhost:7220/api/Abouts");
            return View(abouts);
        }

        [Route("CreateAbout")]
        [HttpGet]
        public IActionResult CreateAbout()
        {
            return View();
        }

        [HttpPost]
        [Route("CreateAbout")]
        public async Task<IActionResult> CreateAbout(CreateAboutDto createAboutDto)
        {
            var responseMessage = await _apiService.PostAsync("https://localhost:7220/api/Abouts", createAboutDto);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "About", new { area = "Admin" });
            }
            return View();
        }

        [Route("DeleteAbout/{id}")]
        [HttpGet]
        public async Task<IActionResult> DeleteAbout(string id)
        {
            var responseMessage = await _apiService.DeleteAsync($"https://localhost:7220/api/Abouts?id={id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "About", new { area = "Admin" });
            }
            return View();
        }

        [Route("UpdateAbout/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateAbout(string id)
        {
            var about = await _apiService.GetAsync<UpdateAboutDto>($"https://localhost:7220/api/Abouts/{id}");
            return View(about);
        }

        [HttpPost]
        [Route("UpdateAbout/{id}")]
        public async Task<IActionResult> UpdateAbout(UpdateAboutDto updateAboutDto)
        {
            var responseMessage = await _apiService.PutAsync("https://localhost:7220/api/Abouts", updateAboutDto);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "About", new { area = "Admin" });
            }
            return View();
        }
    }
}
