using Microsoft.AspNetCore.Mvc;
using OllieShop.WebUI.Services.CatalogServices.OfferServices;

namespace OllieShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class _OfferDefaultComponentPartial:ViewComponent
    {
        private readonly IOfferService _offerService;
        public _OfferDefaultComponentPartial(IOfferService offerService)
        {
            _offerService = offerService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var offers = await _offerService.GetAllOfferAsync();
            return View(offers);
        }
    }
}
