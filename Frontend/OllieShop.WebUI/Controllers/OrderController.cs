using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using OllieShop.DtoLayer.BasketDtos;
using OllieShop.DtoLayer.Enums;
using OllieShop.DtoLayer.OrderDtos.Address;
using OllieShop.DtoLayer.OrderDtos.OrderDetail;
using OllieShop.DtoLayer.OrderDtos.Ordering;
using OllieShop.WebUI.Services.BasketServices;
using OllieShop.WebUI.Services.IUserService;
using OllieShop.WebUI.Services.OrderServices.AddressServices;
using OllieShop.WebUI.Services.OrderServices.OrderDetailServices;
using OllieShop.WebUI.Services.OrderServices.OrderingServices;

namespace OllieShop.WebUI.Controllers
{
    public class OrderController : Controller
    {
        private readonly IAddressService _addressService;
        private readonly IBasketService _basketService;
        private readonly IUserService _userService;
        private readonly IOrderingService _orderingService;
        private readonly IOrderDetailService _orderDetailService;

        public OrderController(IAddressService addressService, IBasketService basketService, IUserService userService, IOrderingService orderingService, IOrderDetailService orderDetailService)
        {
            _addressService = addressService;
            _basketService = basketService;
            _userService = userService;
            _orderingService = orderingService;
            _orderDetailService = orderDetailService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var addresses = await _addressService.GetAllAddressAsync();
            return View(addresses);
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateAddressDto createAddressDto, string? selectedAddressId)
        {
            var basket = await _basketService.GetBasket();

            if (!selectedAddressId.IsNullOrEmpty())
            {
                // Kullanıcı kayıtlı bir adres seçtiyse
                var selectedAddress = await _addressService.GetByIdAddressAsync(selectedAddressId!);
                if (selectedAddress != null)
                {
                    await CreateOrder(selectedAddress.AddressId, selectedAddress.UserId, basket);
                    return RedirectToAction("Index", "Payment");
                }
            }
            else
            {
                // Yeni adres oluşturuluyor
                var user = await _userService.GetUserInfoAsync();
                createAddressDto.UserId = user.Id;
                createAddressDto.Surname = user.Surname;
                createAddressDto.Name = user.Name;
                createAddressDto.Email = user.Email;

                var result = await _addressService.CreateAddressAsync(createAddressDto);
                var address = _addressService.GetAllAddressAsync().Result.LastOrDefault();

                if (result.IsSuccessStatusCode && address != null)
                {
                    await CreateOrder(address.AddressId, createAddressDto.UserId, basket);
                    return RedirectToAction("Index", "Payment");
                }
            }

            return View();
        }

        private async Task CreateOrder(int addressId, string userId, BasketTotalDto basket)
        {
            // Sipariş oluşturuluyor
            var result = await _orderingService.CreateOrderingAsync(new CreateOrderingDto
            {
                OrderDate = DateTime.Now,
                AddressId = addressId,
                Status = OrderStatus.Pending,
                TotalPrice = basket.TotalDiscountedPriceWithShipping,
                UserId = userId
            });

            var lastOrdering = (await _orderingService.GetAllOrderingAsync()).LastOrDefault();

            if (lastOrdering != null)
            {
                var orderingId = lastOrdering.OrderingId;

                // Sipariş detayları ekleniyor
                foreach (var item in basket.BasketItems)
                {
                    await _orderDetailService.CreateOrderDetailAsync(new CreateOrderDetailDto
                    {
                        OrderingId = orderingId,
                        ProductId = item.ProductId,
                        ProductName = item.ProductName,
                        Quantity = item.Quantity,
                        TotalPrice = item.Quantity * item.UnitPrice,
                        UnitPrice = item.UnitPrice
                    });
                }
            }
        }
    }
}
