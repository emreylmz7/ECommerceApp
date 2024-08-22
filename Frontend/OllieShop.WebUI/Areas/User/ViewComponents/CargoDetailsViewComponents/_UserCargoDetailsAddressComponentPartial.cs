using Microsoft.AspNetCore.Mvc;
using OllieShop.WebUI.Services.OrderServices.AddressServices;

namespace OllieShop.WebUI.Areas.User.ViewComponents.CargoDetailsViewComponents
{
    public class _UserCargoDetailsAddressComponentPartial:ViewComponent
    {
        private readonly IAddressService _addressService;
        public _UserCargoDetailsAddressComponentPartial(IAddressService addressService)
        {
            _addressService = addressService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var address = await _addressService.GetByIdAddressAsync(id);
            return View(address);
        }
    }
}
