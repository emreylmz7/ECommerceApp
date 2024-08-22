using Microsoft.AspNetCore.Mvc;
using OllieShop.WebUI.Services.CargoService;

namespace OllieShop.WebUI.Areas.User.ViewComponents.CargoDetailsViewComponents
{
    public class _UserCargoDetailsComponentPartial:ViewComponent
    {
        private readonly ICargoDetailService _cargoDetailService;
        public _UserCargoDetailsComponentPartial(ICargoDetailService cargoDetailService)
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
