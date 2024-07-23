using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using OllieShop.DtoLayer.IdentityDtos;
using OllieShop.WebUI.Models;
using OllieShop.WebUI.Services.ApiServices;
using OllieShop.WebUI.Services.IdentityServices;
using OllieShop.WebUI.Services.LoginServices;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text.Json;

namespace OllieShop.WebUI.Controllers
{
    public class LoginController : Controller
    {
        private readonly IApiService _apiService;
        private readonly ILoginService _loginService;
        private readonly IIdentityService _identityService; 
        public LoginController(IApiService apiService, ILoginService loginService, IIdentityService identityService )
        {
            _loginService = loginService;
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
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> SignIn(LoginDto loginDto)
        {
            
            loginDto.Username = "emreylmz";
            loginDto.Password = "123456aA*";
            await _identityService.SignIn(loginDto);
          
            return RedirectToAction("Index","User");
        }
    }
}
