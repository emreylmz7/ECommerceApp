using Microsoft.AspNetCore.Mvc;
using OllieShop.DtoLayer.CatalogDtos.Vendor;
using OllieShop.WebUI.Services.ApiServices;

namespace OllieShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class _VendorDefaultComponentPartial:ViewComponent
    {
        private readonly IApiService _apiService;
        public _VendorDefaultComponentPartial(IApiService apiService)
        {
            _apiService = apiService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var vendors = await _apiService.GetAsync<List<ResultVendorDto>>("https://localhost:7220/api/Vendors");
            return View(vendors);
        }
    }
}
