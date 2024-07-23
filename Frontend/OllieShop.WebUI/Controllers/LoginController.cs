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
            var responseMessage = await _apiService.PostAsync("http://localhost:5001/api/Login", loginDto);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var tokenModel = JsonSerializer.Deserialize<JwtResponseModel>(jsonData, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });

                if (tokenModel != null)
                {
                    JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
                    var token = handler.ReadJwtToken(tokenModel.Token);
                    var claims = token.Claims.ToList();

                    if (tokenModel.Token != null)
                    {
                        claims.Add(new Claim("OllieShopToken",tokenModel.Token));
                        var claimIdentity = new ClaimsIdentity(claims, JwtBearerDefaults.AuthenticationScheme);
                        var authProps = new AuthenticationProperties
                        {
                            ExpiresUtc = tokenModel.ExpireDate,
                            IsPersistent = true
                        };
                        await HttpContext.SignInAsync(JwtBearerDefaults.AuthenticationScheme, new ClaimsPrincipal(claimIdentity),authProps);
                        var userId = _loginService.GetUserId;

                        return RedirectToAction("Index", "Default");
                    }
                }
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> SignIn(LoginDto loginDto)
        {
            loginDto.Username = "emreylmz";
            loginDto.Password = "123456aA*";
            await _identityService.SignIn(loginDto);
          
            return RedirectToAction("Index","Default");
        }
    }
}
