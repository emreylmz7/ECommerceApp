using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OllieShop.WebUI.Services.OrderServices.OrderingServices;

namespace OllieShop.WebUI.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    [Route("Admin/AdminDashboard")]
    public class AdminDashboardController : Controller
    {
        private readonly IOrderingService _orderingService;
        public AdminDashboardController(IOrderingService orderingService)
        {
            _orderingService = orderingService;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var statistics = await _orderingService.GetAdminOrderingStatisticsAsync();
            return View(statistics);
        }
    }
}
