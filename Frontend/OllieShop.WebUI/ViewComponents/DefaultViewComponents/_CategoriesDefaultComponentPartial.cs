using Microsoft.AspNetCore.Mvc;
using OllieShop.DtoLayer.CatalogDtos.Category;
using OllieShop.WebUI.Services.ApiServices;
using OllieShop.WebUI.Services.TokenServices;

namespace OllieShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class _CategoriesDefaultComponentPartial:ViewComponent
    {
        private readonly IApiService _apiService;
        private readonly ITokenService _tokenService;
        public _CategoriesDefaultComponentPartial(IApiService apiService,ITokenService tokenService)
        {
            _apiService = apiService;
            _tokenService = tokenService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var token = await _tokenService.GetTokenAsync();
            var categories = await _apiService.GetWithTokenAsync<List<ResultCategoryDto>>("https://localhost:7220/api/Categories", token);
            return View(categories);
        }
    }
}
