using Microsoft.AspNetCore.Mvc;
using OllieShop.DtoLayer.CatalogDtos.ProductDetail;
using OllieShop.WebUI.Services.ApiServices;

namespace OllieShop.WebUI.ViewComponents.ProductDetailViewComponents
{
    public class _ProductInformationComponentPartial:ViewComponent
    {
        private readonly IApiService _apiService;
        public _ProductInformationComponentPartial(IApiService apiService)
        {
            _apiService = apiService;
        }
        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var productDetails = await _apiService.GetAsync<ResultProductDetailDto>($"https://localhost:7220/api/ProductDetails/GetProductDetailsByProductId?id={id}");
            return View(productDetails);
        }
    }
}
