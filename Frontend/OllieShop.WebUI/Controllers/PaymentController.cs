using Microsoft.AspNetCore.Mvc;
using OllieShop.DtoLayer.Enums;
using OllieShop.DtoLayer.OrderDtos.Ordering;
using OllieShop.DtoLayer.PaymentDtos;
using OllieShop.WebUI.Services.BasketServices;
using OllieShop.WebUI.Services.IUserService;
using OllieShop.WebUI.Services.OrderServices.OrderDetailServices;
using OllieShop.WebUI.Services.OrderServices.OrderingServices;
using OllieShop.WebUI.Services.PaymentServices;

namespace OllieShop.WebUI.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IOrderingService _orderingService;
        private readonly IPaymentService _paymentService;
        private readonly IBasketService _basketService;
        private readonly IOrderDetailService _orderDetailService;
        private readonly IUserService _userService;

        public PaymentController(
            IOrderingService orderingService,
            IPaymentService paymentService,
            IBasketService basketService,
            IOrderDetailService orderDetailService,
            IUserService userService)
        {
            _orderingService = orderingService;
            _paymentService = paymentService;
            _basketService = basketService;
            _orderDetailService = orderDetailService;
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string orderId)
        {
            if (string.IsNullOrEmpty(orderId))
            {
                return RedirectToAction("Index", "ShoppingCart");
            }

            var order = await _orderingService.GetByIdOrderingAsync(orderId);
            if (order == null)
            {
                // Handle case where order is not found
                return RedirectToAction("Error", "Home"); // You can create an error page or appropriate action
            }

            ViewBag.OrderId = orderId;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreatePaymentDto createPaymentDto)
        {
            var order = await _orderingService.GetByIdOrderingAsync(createPaymentDto.OrderId);
            if (order == null)
            {
                // Handle case where order is not found
                return RedirectToAction("Error", "Home"); // You can create an error page or appropriate action
            }

            createPaymentDto.Amount = order.TotalPrice;
            createPaymentDto.PaymentMethod = "Credit Card";

            var result = await _paymentService.CreatePaymentAsync(createPaymentDto);
            if (result.IsSuccessStatusCode)
            {
                var user = await _userService.GetUserInfoAsync();

                var response = await _basketService.DeleteBasket();

                var updateOrderingDto = new UpdateOrderingDto
                {
                    AddressId = order.AddressId,
                    OrderDate = order.OrderDate,
                    Status = OrderStatus.Processing,
                    TotalPrice = order.TotalPrice,
                    UserId = user?.Id,
                    OrderingId = order.OrderingId
                };
                await _orderingService.UpdateOrderingAsync(updateOrderingDto);

                return RedirectToAction("Success", "Payment"); // Redirect to a success page
            }

            // Handle failure case
            ModelState.AddModelError("", "Payment failed. Please try again.");
            return View(createPaymentDto);
        }

        [HttpGet]
        public IActionResult Success()
        {
            return View();
        }
    }
}
