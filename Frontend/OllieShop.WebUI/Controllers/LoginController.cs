using Microsoft.AspNetCore.Mvc;
using OllieShop.DtoLayer.IdentityDtos;
using OllieShop.WebUI.Services.IdentityServices;

namespace OllieShop.WebUI.Controllers
{
    public class LoginController : Controller
    {
        private readonly IIdentityService _identityService; 
        public LoginController(IIdentityService identityService )
        {
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

        public async Task<IActionResult> LogOut()
        {
            await _identityService.LogOut();
            return RedirectToAction("Index","Default");
        }
    }
}
