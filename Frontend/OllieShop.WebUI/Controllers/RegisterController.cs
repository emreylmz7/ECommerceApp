using Microsoft.AspNetCore.Mvc;
using OllieShop.DtoLayer.IdentityDtos;
using OllieShop.WebUI.Services.ApiServices;

namespace OllieShop.WebUI.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IApiService _apiService;
        public RegisterController(IApiService apiService)
        {
            _apiService = apiService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(RegisterDto registerDto)
        {
            var responseMessage = await _apiService.PostAsync("http://localhost:5001/api/Registers", registerDto);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Default");
            }
            return View();
        }
    }
}
