using Microsoft.AspNetCore.Mvc;
using OllieShop.WebUI.Services.OrderServices.AddressServices;

namespace OllieShop.WebUI.Areas.Admin.ViewComponents.CargoViewComponents
{
    public class _CargoDetailsAddressComponentPartial:ViewComponent
    {
        private readonly IAddressService _addressService;
        public _CargoDetailsAddressComponentPartial(IAddressService addressService)
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
