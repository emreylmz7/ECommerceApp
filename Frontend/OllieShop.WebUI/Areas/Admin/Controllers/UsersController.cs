using Microsoft.AspNetCore.Mvc;
using OllieShop.WebUI.Services.IUserService;

namespace OllieShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Users")]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var users = await _userService.GetUserListAsync();
            return View(users);
        }
    }
}
