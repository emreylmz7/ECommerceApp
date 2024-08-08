using Microsoft.AspNetCore.Mvc;
using OllieShop.DtoLayer.OrderDtos.Address;
using OllieShop.WebUI.Services.IUserService;
using OllieShop.WebUI.Services.OrderServices.AddressServices;

namespace OllieShop.WebUI.Controllers
{
    public class OrderController : Controller
    {
        private readonly IAddressService _addressService;
        private readonly IUserService _userService;
        public OrderController(IAddressService addressService, IUserService userService)
        {
            _addressService = addressService;
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var adresses = await _addressService.GetAllAddressAsync(); 
            return View(adresses);
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateAddressDto createAddressDto)
        {
            var user = await _userService.GetUserInfoAsync();
            createAddressDto.UserId = user.Id;
            createAddressDto.Surname = user.Surname;
            createAddressDto.Name = user.Name;
            createAddressDto.Email = user.Email;

            var result = await _addressService.CreateAddressAsync(createAddressDto);
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index","Payment");
            }
            return View();
        }
    }
}
