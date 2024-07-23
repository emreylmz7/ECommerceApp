using Microsoft.AspNetCore.Mvc;
using OllieShop.DtoLayer.CatalogDtos.About;
using OllieShop.DtoLayer.CatalogDtos.Contact;
using OllieShop.WebUI.Services.ApiServices;

namespace OllieShop.WebUI.Controllers
{
    public class ContactController : Controller
    {
        private readonly IApiService _apiService;
        public ContactController(IApiService apiService)
        {
            _apiService = apiService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var abouts = (await _apiService.GetAsync<List<ResultAboutDto>>("https://localhost:7220/api/Abouts")).Take(1).ToList();
            return View(abouts);
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateContactDto createContactDto)
        {
            createContactDto.SendDate = DateTime.Now;
            createContactDto.IsRead = true;

            var responseMessage = await _apiService.PostAsync("https://localhost:7220/api/Contacts", createContactDto);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Default");
            }
            return View();
        }
    }
}
