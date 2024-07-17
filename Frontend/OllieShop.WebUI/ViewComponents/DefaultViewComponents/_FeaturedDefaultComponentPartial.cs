using Microsoft.AspNetCore.Mvc;
using OllieShop.DtoLayer.CatalogDtos.Feature;
using OllieShop.WebUI.Services.ApiServices;

namespace OllieShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class _FeaturedDefaultComponentPartial:ViewComponent
    {
        private readonly IApiService _apiService;
        public _FeaturedDefaultComponentPartial(IApiService apiService)
        {
            _apiService = apiService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var features = await _apiService.GetAsync<List<ResultFeatureDto>>("https://localhost:7220/api/Features");
            return View(features);
        }
    }
}
