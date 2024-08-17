using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OllieShop.DtoLayer.CatalogDtos.ProductStock;
using OllieShop.DtoLayer.Enums;
using OllieShop.DtoLayer.OrderDtos.Ordering;
using OllieShop.DtoLayer.PaymentDtos;
using OllieShop.WebUI.Services.BasketServices;
using OllieShop.WebUI.Services.CatalogServices.ProductStockServices;
using OllieShop.WebUI.Services.IUserService;
using OllieShop.WebUI.Services.OrderServices.OrderDetailServices;
using OllieShop.WebUI.Services.OrderServices.OrderingServices;
using OllieShop.WebUI.Services.PaymentServices;

namespace OllieShop.WebUI.Controllers
{
    [Authorize]
    public class PaymentController : Controller
    {
        private readonly IOrderingService _orderingService;
        private readonly IPaymentService _paymentService;
        private readonly IBasketService _basketService;
        private readonly IOrderDetailService _orderDetailService;
        private readonly IUserService _userService;
        private readonly IProductStockService _productStockService;

        public PaymentController(
            IOrderingService orderingService,
            IPaymentService paymentService,
            IBasketService basketService,
            IOrderDetailService orderDetailService,
            IUserService userService,
            IProductStockService productStockService)
        {
            _orderingService = orderingService;
            _paymentService = paymentService;
            _basketService = basketService;
            _orderDetailService = orderDetailService;
            _userService = userService;
            _productStockService = productStockService;
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
                return RedirectToAction("Error", "Home");
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
                return RedirectToAction("Error", "Home");
            }

            createPaymentDto.Amount = order.TotalPrice;
            createPaymentDto.PaymentMethod = "Credit Card";

            var paymentResult = await _paymentService.CreatePaymentAsync(createPaymentDto);
            if (paymentResult.IsSuccessStatusCode)
            {
                var user = await _userService.GetUserInfoAsync();
                var basket = await _basketService.GetBasket();

                if (basket != null)
                {
                    foreach (var item in basket.BasketItems)
                    {
                        var productStocks = await _productStockService.GetProductStocksByProductId(item.ProductId);
                        if (productStocks != null)
                        {
                            var stock = productStocks.FirstOrDefault(x => x.SizeId == item.SizeId && x.ColorId == item.ColorId);
                            if (stock != null)
                            {
                                stock.Stock -= item.Quantity;
                                await _productStockService.UpdateProductStockAsync(new UpdateProductStockDto
                                {
                                    ColorId = stock.ColorId,
                                    ProductId = stock.ProductId,
                                    ProductStockId = stock.ProductId,
                                    SizeId = stock.SizeId,
                                    Stock = stock.Stock
                                });
                            }
                        }
                    }
                }

                await _basketService.DeleteBasket();

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

                return RedirectToAction("Success", "Payment");
            }

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
