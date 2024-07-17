using Microsoft.AspNetCore.Mvc;
using OllieShop.DtoLayer.CatalogDtos.Product;
using OllieShop.WebUI.Services.ApiServices;

namespace OllieShop.WebUI.ViewComponents.ProductDetailViewComponents
{
    public class _ProductPreviewComponentPartial: ViewComponent
    {
        private readonly IApiService _apiService;
        public _ProductPreviewComponentPartial(IApiService apiService)
        {
            _apiService = apiService;
        }
        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var product = await _apiService.GetAsync<ResultProductDto>($"https://localhost:7220/api/Products/{id}");
            return View(product);
        }
    }
}
