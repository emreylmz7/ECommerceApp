using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OllieShop.DtoLayer.OrderDtos.Address;
using OllieShop.WebUI.Services.OrderServices.AddressServices;

namespace OllieShop.WebUI.Areas.User.Controllers
{
    [Authorize]
    [Area("User")]
    [Route("User/Addresses")]
    public class AddressesController : Controller
    {
        private readonly IAddressService _addressService;

        public AddressesController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        [Route("Index")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var addresses = await _addressService.GetAllAddressAsync();
            return View(addresses);
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
                return Redirect("/User/Addresses/Index");
            }
            return View();
        }

        [Route("EditAddress")]
        [HttpGet]
        public async Task<IActionResult> EditAddress(string id)
        {
            var address = await _addressService.GetByIdAddressAsync(id);
            if (address == null)
            {
                return NotFound();
            }
            UpdateAddressDto updateAddress = new UpdateAddressDto()
            {
                AddressId = address.AddressId,
                Description = address.Description,
                City = address.City,
                Country = address.Country,
                Email = address.Email,
                Name = address.Name,
                PhoneNumber = address.PhoneNumber,
                Surname = address.Surname,
                UserId = address.UserId,
                ZipCode = address.ZipCode
            };
            
            return View(updateAddress);
        }

        [Route("EditAddress")]
        [HttpPost]
        public async Task<IActionResult> EditAddress(UpdateAddressDto updateAddressDto)
        {
            var result = await _addressService.UpdateAddressAsync(updateAddressDto);
            if (result.IsSuccessStatusCode)
            {
                return Redirect("/User/Addresses/Index");
            }
            return View();
        }

        [Route("DeleteAddress")]
        [HttpGet]
        public async Task<IActionResult> DeleteAddress(string id)
        {
            var result = await _addressService.DeleteAddressAsync(id);
            if (result.IsSuccessStatusCode)
            {
                return Redirect("/User/Addresses/Index");
            }
            return View();
        }
    }
}
