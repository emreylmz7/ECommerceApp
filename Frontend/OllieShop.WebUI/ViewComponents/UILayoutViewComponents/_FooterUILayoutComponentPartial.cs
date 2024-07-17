using Microsoft.AspNetCore.Mvc;
using OllieShop.DtoLayer.CatalogDtos.About;
using OllieShop.WebUI.Services.ApiServices;

namespace OllieShop.WebUI.ViewComponents.UILayoutViewComponents
{
    public class _FooterUILayoutComponentPartial : ViewComponent
    {
        private readonly IApiService _apiService;
        public _FooterUILayoutComponentPartial(IApiService apiService)
        {
            _apiService = apiService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var abouts = (await _apiService.GetAsync<List<ResultAboutDto>>("https://localhost:7220/api/Abouts")).Take(1).ToList();
            return View(abouts);
        }
    }
}
