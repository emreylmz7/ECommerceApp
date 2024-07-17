using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OllieShop.DtoLayer.CatalogDtos.Feature;
using OllieShop.WebUI.Services.ApiServices;

namespace OllieShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    [Route("Admin/Feature")]
    public class FeatureController : Controller
    {
        private readonly IApiService _apiService;

        public FeatureController(IApiService apiService)
        {
            _apiService = apiService;
        }

        [Route("Index")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var features = await _apiService.GetAsync<List<ResultFeatureDto>>("https://localhost:7220/api/Features");
            return View(features);
        }

        [Route("CreateFeature")]
        [HttpGet]
        public IActionResult CreateFeature()
        {
            return View();
        }

        [HttpPost]
        [Route("CreateFeature")]
        public async Task<IActionResult> CreateFeature(CreateFeatureDto createFeatureDto)
        {
            var responseMessage = await _apiService.PostAsync("https://localhost:7220/api/Features", createFeatureDto);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Feature", new { area = "Admin" });
            }
            return View();
        }

        [Route("DeleteFeature/{id}")]
        [HttpGet]
        public async Task<IActionResult> DeleteFeature(string id)
        {
            var responseMessage = await _apiService.DeleteAsync($"https://localhost:7220/api/Features?id={id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Feature", new { area = "Admin" });
            }
            return View();
        }

        [Route("UpdateFeature/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateFeature(string id)
        {
            var feature = await _apiService.GetAsync<UpdateFeatureDto>($"https://localhost:7220/api/Features/{id}");
            return View(feature);
        }

        [HttpPost]
        [Route("UpdateFeature/{id}")]
        public async Task<IActionResult> UpdateFeature(UpdateFeatureDto updateFeatureDto)
        {
            var responseMessage = await _apiService.PutAsync("https://localhost:7220/api/Features", updateFeatureDto);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Feature", new { area = "Admin" });
            }
            return View();
        }
    }
}
