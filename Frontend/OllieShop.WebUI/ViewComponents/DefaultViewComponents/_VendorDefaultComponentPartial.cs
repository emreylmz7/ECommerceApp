using Microsoft.AspNetCore.Mvc;
using OllieShop.WebUI.Services.CatalogServices.VendorServices;

namespace OllieShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class _VendorDefaultComponentPartial:ViewComponent
    {
        private readonly IVendorService _vendorService;
        public _VendorDefaultComponentPartial(IVendorService vendorService)
        {
            _vendorService = vendorService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var vendors = await _vendorService.GetAllVendorAsync();
            return View(vendors);
        }
    }
}
