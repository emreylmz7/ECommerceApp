using Microsoft.AspNetCore.Mvc;
using OllieShop.WebUI.Services.OrderServices.AddressServices;

namespace OllieShop.WebUI.Areas.User.ViewComponents.ProfileViewComponents
{
	public class _ProfileAddressesComponentPartial:ViewComponent
	{
		private readonly IAddressService _addressService;
		public _ProfileAddressesComponentPartial(IAddressService addressService)
		{
			_addressService = addressService;
		}

		public async Task<IViewComponentResult> InvokeAsync(string id)
		{
			ViewBag.UserId = id;
			var addresses = await _addressService.GetAllAddressAsync();
			return View(addresses);
		}
	}
}
