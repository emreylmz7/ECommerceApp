using Microsoft.AspNetCore.Mvc;
using OllieShop.DtoLayer.CatalogDtos.Product;
using OllieShop.WebUI.Services.ApiServices;

namespace OllieShop.WebUI.ViewComponents.ProductListViewComponents
{
    public class _ProductListComponentPartial:ViewComponent
    {
        private readonly IApiService _apiService;
        public _ProductListComponentPartial(IApiService apiService)
        {
            _apiService = apiService;
        }
        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var products = await _apiService.GetAsync<List<ResultProductsWithCategoryDto>>($"https://localhost:7220/api/Products/ProductListByCategory?id={id}");
            return View(products);
        }
    }
}
