using Microsoft.AspNetCore.Mvc;
using OllieShop.DtoLayer.CatalogDtos.Offer;
using OllieShop.WebUI.Services.ApiServices;

namespace OllieShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class _OfferDefaultComponentPartial:ViewComponent
    {
        private readonly IApiService _apiService;
        public _OfferDefaultComponentPartial(IApiService apiService)
        {
            _apiService = apiService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var offers = await _apiService.GetAsync<List<ResultOfferDto>>("https://localhost:7220/api/Offers");
            return View(offers);
        }
    }
}
