using Microsoft.AspNetCore.Mvc;
using OllieShop.DtoLayer.CatalogDtos.About;
using OllieShop.WebUI.Services.CatalogServices.AboutServices;

namespace OllieShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/About")]
    public class AboutController : Controller
    {
        private readonly IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        [Route("Index")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var abouts = await _aboutService.GetAllAboutAsync();
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
            var responseMessage = await _aboutService.CreateAboutAsync(createAboutDto);
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
            var responseMessage = await _aboutService.DeleteAboutAsync(id);
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
            var about = await _aboutService.GetByIdAboutAsync(id);
            var about2 = new UpdateAboutDto
            {
                AboutId = about.AboutId,
                Address = about.Address,
                Description = about.Description,    
                Email = about.Email,    
                Phone = about.Phone,
                Title = about.Title,
            };
            return View(about2);
        }

        [HttpPost]
        [Route("UpdateAbout/{id}")]
        public async Task<IActionResult> UpdateAbout(UpdateAboutDto updateAboutDto)
        {
            var responseMessage = await _aboutService.UpdateAboutAsync(updateAboutDto);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "About", new { area = "Admin" });
            }
            return View();
        }
    }
}
