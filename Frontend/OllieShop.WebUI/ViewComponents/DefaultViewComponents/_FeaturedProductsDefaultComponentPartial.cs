using Microsoft.AspNetCore.Mvc;
using OllieShop.DtoLayer.CatalogDtos.Product;
using OllieShop.WebUI.Services.ApiServices;

namespace OllieShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class _FeaturedProductsDefaultComponentPartial:ViewComponent
    {
        private readonly IApiService _apiService;
        public _FeaturedProductsDefaultComponentPartial(IApiService apiService)
        {
            _apiService = apiService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var products = (await _apiService.GetAsync<List<ResultProductDto>>("https://localhost:7220/api/Products")).Take(8).ToList();
            return View(products);
        }
    }
}
