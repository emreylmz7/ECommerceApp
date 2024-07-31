using Microsoft.AspNetCore.Mvc;
using OllieShop.DtoLayer.CatalogDtos.Feature;
using OllieShop.WebUI.Services.ApiServices;
using OllieShop.WebUI.Services.CatalogServices.FeatureServices;

namespace OllieShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class _FeaturedDefaultComponentPartial:ViewComponent
    {
        private readonly IFeatureService _featureService;
        public _FeaturedDefaultComponentPartial(IFeatureService featureService)
        {
            _featureService = featureService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var features = await _featureService.GetAllFeatureAsync();
            return View(features);
        }
    }
}
