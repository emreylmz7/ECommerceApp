using Microsoft.AspNetCore.Mvc;
using OllieShop.DtoLayer.IdentityDtos;
using OllieShop.WebUI.Services.ApiServices;
using OllieShop.WebUI.Services.IdentityServices;

namespace OllieShop.WebUI.Controllers
{
    public class LoginController : Controller
    {
        private readonly IApiService _apiService;
        private readonly IIdentityService _identityService; 
        public LoginController(IApiService apiService, IIdentityService identityService )
        {
            _apiService = apiService;
            _identityService = identityService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginDto loginDto)
        {
            var result = await _identityService.SignIn(loginDto);
            if (result == true)
            {
                return RedirectToAction("Index", "Default");
            }
            return View();
        }
    }
}
