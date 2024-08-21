using Microsoft.AspNetCore.Mvc;
using OllieShop.WebUI.Services.CargoService;
using OllieShop.WebUI.Services.OrderServices.OrderDetailServices;

namespace OllieShop.WebUI.Areas.Admin.ViewComponents.CargoViewComponents
{
    public class _CargoDetailsComponentPartial:ViewComponent
    {
        private readonly ICargoDetailService _cargoDetailService;
        public _CargoDetailsComponentPartial(ICargoDetailService cargoDetailService)
        {
            _cargoDetailService = cargoDetailService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var cargoDetails = await _cargoDetailService.GetCargoDetailsByCargoIdAsync(id);
            return View(cargoDetails);
        }
    }
}
