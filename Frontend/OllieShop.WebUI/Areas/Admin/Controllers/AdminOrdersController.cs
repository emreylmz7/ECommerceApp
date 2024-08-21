using Microsoft.AspNetCore.Mvc;
using OllieShop.WebUI.Services.OrderServices.OrderingServices;
using System.Globalization;

namespace OllieShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminOrders")]
    public class AdminOrdersController : Controller
    {
        private readonly IOrderingService _orderingService;
        public AdminOrdersController(IOrderingService orderingService)
        {
            _orderingService = orderingService;
        }

        [Route("Index")]
        [HttpGet]
        public async Task<IActionResult> Index(int pageNumber = 1, int pageSize = 10)
        {
            var orderStatistics = await _orderingService.GetAdminOrderingStatisticsAsync();
            var orders = (await _orderingService.GetAllOrderingAsync())
                            .OrderByDescending(o => o.OrderingId)
                            .Skip((pageNumber - 1) * pageSize)
                            .Take(pageSize)
                            .ToList();

            ViewBag.TotalPages = (int)Math.Ceiling(orderStatistics.TotalOrders / (double)pageSize);
            ViewBag.CurrentPage = pageNumber;

            ViewBag.One = "Total Sales";
            ViewBag.OneDesc = orderStatistics.TotalSales.ToString("C", new CultureInfo("en-US"));
            ViewBag.OneIcon = "bx bx-dollar bx-lg text-success p-3";

            ViewBag.Two = "Pending Orders";
            ViewBag.TwoDesc = orderStatistics.PendingOrdersCount;
            ViewBag.TwoIcon = "bx bx-time bx-lg text-info p-3";

            ViewBag.Three = "Completed Orders";
            ViewBag.ThreeDesc = orderStatistics.CompletedOrdersCount;
            ViewBag.ThreeIcon = "bx bx-check bx-lg text-warning p-3";

            ViewBag.Four = "Average Order Value";
            ViewBag.FourDesc = orderStatistics.AverageOrderValue.ToString("C", new CultureInfo("en-US"));
            ViewBag.FourIcon = "bx bx-line-chart bx-lg text-primary p-3"; 


            return View(orders);
        }
    }
}
