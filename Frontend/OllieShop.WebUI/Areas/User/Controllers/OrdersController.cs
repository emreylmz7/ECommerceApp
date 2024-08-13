using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OllieShop.WebUI.Services.IUserService;
using OllieShop.WebUI.Services.OrderServices.AddressServices;
using OllieShop.WebUI.Services.OrderServices.OrderDetailServices;
using OllieShop.WebUI.Services.OrderServices.OrderingServices;

namespace OllieShop.WebUI.Areas.User.Controllers
{
    [Authorize]
    [Area("User")]
    [Route("User/Orders")]
    public class OrdersController : Controller
    {
        private readonly IOrderingService _orderingService;
        private readonly IOrderDetailService _orderDetailService;
        private readonly IAddressService _addressService;
        private readonly IUserService _userService;

        public OrdersController(IOrderingService orderingService, IOrderDetailService orderDetailService, IAddressService addressService, IUserService userService)
        {
            _orderingService = orderingService;
            _orderDetailService = orderDetailService;
            _addressService = addressService;
            _userService = userService;
        }

        [Route("Index")]
        [HttpGet]
        public async Task<IActionResult> Index(int pageNumber = 1, int pageSize = 10)
        {
            ViewBag.Title = "My Orders";
            var orders = (await _orderingService.GetOrderingsByUserAsync())
                            .OrderByDescending(o => o.OrderDate)
                            .Skip((pageNumber - 1) * pageSize)
                            .Take(pageSize)
                            .ToList();

            var totalOrders = await _orderingService.GetTotalOrdersCountAsync(); 
            ViewBag.TotalPages = (int)Math.Ceiling(totalOrders / (double)pageSize);
            ViewBag.CurrentPage = pageNumber;

            return View(orders);
        }


        [Route("OrderDetails")]
        [HttpGet]
        public async Task<IActionResult> OrderDetails(string id)
        {
            ViewBag.Title = "Order Details";

            var order = await _orderingService.GetByIdOrderingAsync(id);
            var user = await _userService.GetUserInfoAsync();

            ViewData["address"] = await _addressService.GetByIdAddressAsync(order.AddressId.ToString());
            ViewData["user"] = user;

            return View(order);
        }
    }
}
