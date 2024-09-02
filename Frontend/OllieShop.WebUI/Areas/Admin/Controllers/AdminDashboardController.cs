using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OllieShop.WebUI.Services.IUserService;
using OllieShop.WebUI.Services.OrderServices.OrderingServices;

namespace OllieShop.WebUI.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    [Route("Admin/AdminDashboard")]
    public class AdminDashboardController : Controller
    {
        private readonly IOrderingService _orderingService;
        private readonly IUserService _userService;
        public AdminDashboardController(IOrderingService orderingService, IUserService userService)
        {
            _orderingService = orderingService;
            _userService = userService;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var user = await _userService.GetUserInfoAsync();
            ViewBag.Name = "User";
            if (user != null)
            {
                ViewBag.Name = user.Name;
            }
            var statistics = await _orderingService.GetAdminOrderingStatisticsAsync();
            return View(statistics);
        }
    }
}
