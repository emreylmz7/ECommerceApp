using Microsoft.AspNetCore.Mvc;
using OllieShop.DtoLayer.CatalogDtos.Color;
using OllieShop.WebUI.Services.CatalogServices.ColorServices;

namespace OllieShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Color")]
    public class ColorController : Controller
    {
        private readonly IColorService _colorService;

        public ColorController(IColorService colorService)
        {
            _colorService = colorService;
        }

        [Route("Index")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var colors = await _colorService.GetAllColorAsync();
            return View(colors);
        }

        [Route("CreateColor")]
        [HttpGet]
        public IActionResult CreateColor()
        {
            return View();
        }

        [HttpPost]
        [Route("CreateColor")]
        public async Task<IActionResult> CreateColor(CreateColorDto createColorDto)
        {
            var responseMessage = await _colorService.CreateColorAsync(createColorDto);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Color", new { area = "Admin" });
            }
            return View();
        }

        [Route("DeleteColor/{id}")]
        [HttpGet]
        public async Task<IActionResult> DeleteColor(string id)
        {
            var responseMessage = await _colorService.DeleteColorAsync(id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Color", new { area = "Admin" });
            }
            return View();
        }

        [Route("UpdateColor/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateColor(string id)
        {
            var color = await _colorService.GetByIdColorAsync(id);
            var colorDto = new UpdateColorDto
            {
                ColorId = color.ColorId,
                Name = color.Name
            };
            return View(colorDto);
        }

        [HttpPost]
        [Route("UpdateColor/{id}")]
        public async Task<IActionResult> UpdateColor(UpdateColorDto updateColorDto)
        {
            var responseMessage = await _colorService.UpdateColorAsync(updateColorDto);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Color", new { area = "Admin" });
            }
            return View();
        }
    }
}
