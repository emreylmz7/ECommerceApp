using Microsoft.AspNetCore.Mvc;
using OllieShop.DtoLayer.CatalogDtos.Size;
using OllieShop.WebUI.Services.CatalogServices.SizeServices;

namespace OllieShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Size")]
    public class SizeController : Controller
    {
        private readonly ISizeService _sizeService;

        public SizeController(ISizeService sizeService)
        {
            _sizeService = sizeService;
        }

        [Route("Index")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var sizes = await _sizeService.GetAllSizeAsync();
            return View(sizes);
        }

        [Route("CreateSize")]
        [HttpGet]
        public IActionResult CreateSize()
        {
            return View();
        }

        [HttpPost]
        [Route("CreateSize")]
        public async Task<IActionResult> CreateSize(CreateSizeDto createSizeDto)
        {
            var responseMessage = await _sizeService.CreateSizeAsync(createSizeDto);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Size", new { area = "Admin" });
            }
            return View();
        }

        [Route("DeleteSize/{id}")]
        [HttpGet]
        public async Task<IActionResult> DeleteSize(string id)
        {
            var responseMessage = await _sizeService.DeleteSizeAsync(id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Size", new { area = "Admin" });
            }
            return View();
        }

        [Route("UpdateSize/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateSize(string id)
        {
            var size = await _sizeService.GetByIdSizeAsync(id);
            var sizeDto = new UpdateSizeDto
            {
                SizeId = size.SizeId,
                Name = size.Name
            };
            return View(sizeDto);
        }

        [HttpPost]
        [Route("UpdateSize/{id}")]
        public async Task<IActionResult> UpdateSize(UpdateSizeDto updateSizeDto)
        {
            var responseMessage = await _sizeService.UpdateSizeAsync(updateSizeDto);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Size", new { area = "Admin" });
            }
            return View();
        }
    }
}
