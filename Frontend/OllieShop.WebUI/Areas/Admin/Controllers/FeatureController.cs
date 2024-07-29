using Microsoft.AspNetCore.Mvc;
using OllieShop.DtoLayer.CatalogDtos.Feature;
using OllieShop.WebUI.Services.CatalogServices.FeatureServices;

namespace OllieShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Feature")]
    public class FeatureController : Controller
    {
        private readonly IFeatureService _featureService;

        public FeatureController(IFeatureService featureService)
        {
            _featureService = featureService;
        }

        [Route("Index")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var features = await _featureService.GetAllFeatureAsync();
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
            var responseMessage = await _featureService.CreateFeatureAsync(createFeatureDto);
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
            var responseMessage = await _featureService.DeleteFeatureAsync(id);
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
            var feature = await _featureService.GetByIdFeatureAsync(id);
            var updateFeatureDto = new UpdateFeatureDto
            {
                FeatureId = feature.FeatureId,
                Icon = feature.Icon,
                Title = feature.Title,
            };
            return View(updateFeatureDto);
        }

        [HttpPost]
        [Route("UpdateFeature/{id}")]
        public async Task<IActionResult> UpdateFeature(UpdateFeatureDto updateFeatureDto)
        {
            var responseMessage = await _featureService.UpdateFeatureAsync(updateFeatureDto);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Feature", new { area = "Admin" });
            }
            return View();
        }
    }
}
