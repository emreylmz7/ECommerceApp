using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OllieShop.WebUI.Services.IUserService;

namespace OllieShop.WebUI.Areas.User.Controllers
{
    [Authorize]
    [Area("User")]
    [Route("User/UserDashboard")]
    public class UserDashboardController : Controller
    {
        private readonly IUserService _userService;
        public UserDashboardController(IUserService userService)
        {
            _userService = userService;
        }

        [Route("Index")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await _userService.GetUserInfoAsync();
            return View(user);
        }
    }
}
