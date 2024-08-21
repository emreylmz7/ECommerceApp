using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OllieShop.DtoLayer.CargoDtos.Cargo;
using OllieShop.DtoLayer.CargoDtos.CargoDetail;
using OllieShop.DtoLayer.CatalogDtos.ProductStock;
using OllieShop.DtoLayer.Enums;
using OllieShop.DtoLayer.OrderDtos.Ordering;
using OllieShop.DtoLayer.PaymentDtos;
using OllieShop.WebUI.Services.BasketServices;
using OllieShop.WebUI.Services.CargoService;
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
        private readonly ICargoService _cargoService;
        private readonly ICargoDetailService _cargoDetailService;

        public PaymentController(
            IOrderingService orderingService,
            IPaymentService paymentService,
            IBasketService basketService,
            IOrderDetailService orderDetailService,
            IUserService userService,
            IProductStockService productStockService,
            ICargoService cargoService,
            ICargoDetailService cargoDetailService)
        {
            _orderingService = orderingService;
            _paymentService = paymentService;
            _basketService = basketService;
            _orderDetailService = orderDetailService;
            _userService = userService;
            _productStockService = productStockService;
            _cargoService = cargoService;
            _cargoDetailService = cargoDetailService;
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
                    var trackingNumber = GenerateTrackingNumber();

                    var response = await _cargoService.CreateCargoAsync(new CreateCargoDto
                    {
                        AddressId = order.AddressId.ToString(),
                        OrderId = order.OrderingId,
                        UserId = user.Id,
                        Status = CargoStatus.InTransit,
                        DispatchDate = DateTime.Now,
                        DeliveryDate = DateTime.Now.AddDays(3),
                        TrackingNumber = trackingNumber
                    });

                    var cargoId = 0;

                    if (response.IsSuccessStatusCode)
                    {
                        var cargos = await _cargoService.GetAllCargoAsync();
                        cargoId = cargos.LastOrDefault()?.CargoId ?? 0;
                    }

                    foreach (var item in basket.BasketItems)
                    {
                        // Cargo Detail Process
                        await _cargoDetailService.CreateCargoDetailAsync(new CreateCargoDetailDto
                        {
                            CargoId = cargoId,
                            ProductName = item.ProductName,
                            Quantity = item.Quantity,
                            TotalPrice = item.UnitPrice * item.Quantity,
                            UnitPrice = item.UnitPrice,
                        });

                        // Stock Process
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

        private string GenerateTrackingNumber()
        {
            var random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, 10)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
