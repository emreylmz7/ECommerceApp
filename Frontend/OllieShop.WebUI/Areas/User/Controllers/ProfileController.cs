using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OllieShop.DtoLayer.OrderDtos.Address;
using OllieShop.WebUI.Services.IUserService;
using OllieShop.WebUI.Services.OrderServices.AddressServices;

namespace OllieShop.WebUI.Areas.User.Controllers
{
    [Authorize]
    [Area("User")]
	[Route("User/Profile")]
	public class ProfileController : Controller
	{
		private readonly IUserService _userService;
		private readonly IAddressService _addressService;
		public ProfileController(IUserService userService, IAddressService addressService)
		{
			_userService = userService;
			_addressService = addressService;
		}

		[Route("Index")]
		[HttpGet]
		public async Task<IActionResult> Index()
		{
			ViewBag.Title = "Profile";
			var user = await _userService.GetUserInfoAsync();
			var addresses = await _addressService.GetAllAddressAsync();

			// Adres listesi boşsa varsayılan bir adres ekle
			if (addresses == null || addresses.Count == 0)
			{
				addresses = new List<ResultAddressDto>
				{
					new ResultAddressDto
					{
						City = "",
						Description = "None",
						Country = "",
						PhoneNumber = "None",
						ZipCode = ""
					}
				};
			}

			ViewData["address"] = addresses;
			return View(user);
		}

        [Route("CreateAddress")]
        [HttpGet]
        public IActionResult CreateAddress(string id)
        {
			ViewBag.UserId = id;
            return View();
        }

        [Route("CreateAddress")]
        [HttpPost]
        public async Task<IActionResult> CreateAddress(CreateAddressDto createAddressDto)
		{
			var result = await _addressService.CreateAddressAsync(createAddressDto);
            if (result.IsSuccessStatusCode)
            {
				return Redirect("/User/Profile/Index");
            }
			return View();
        }
	}
}
