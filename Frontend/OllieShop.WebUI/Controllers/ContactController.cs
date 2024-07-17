using Microsoft.AspNetCore.Mvc;
using OllieShop.DtoLayer.CatalogDtos.About;
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

        public async Task<IActionResult> Index()
        {
            var abouts = (await _apiService.GetAsync<List<ResultAboutDto>>("https://localhost:7220/api/Abouts")).Take(1).ToList();
            return View(abouts);
        }
    }
}
