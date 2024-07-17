using Microsoft.AspNetCore.Mvc;
using OllieShop.DtoLayer.CatalogDtos.Category;
using OllieShop.WebUI.Services.ApiServices;

namespace OllieShop.WebUI.ViewComponents.UILayoutViewComponents
{
    public class _NavbarUILayoutComponentPartial:ViewComponent
    {
        private readonly IApiService _apiService;
        public _NavbarUILayoutComponentPartial(IApiService apiService)
        {
            _apiService = apiService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = await _apiService.GetAsync<List<ResultCategoryDto>>("https://localhost:7220/api/Categories");
            return View(categories);
        }
    }
}
