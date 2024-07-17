using Microsoft.AspNetCore.Mvc;
using OllieShop.DtoLayer.CatalogDtos.ProductImage;
using OllieShop.WebUI.Services.ApiServices;

namespace OllieShop.WebUI.ViewComponents.ProductDetailViewComponents
{
    public class _ProductDetailImageSliderComponentPartial:ViewComponent
    {
        private readonly IApiService _apiService;
        public _ProductDetailImageSliderComponentPartial(IApiService apiService)
        {
            _apiService = apiService;
        }
        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var productImages = await _apiService.GetAsync<ResultProductImageDto>($"https://localhost:7220/api/ProductImages/GetImagesByProductId?id={id}");
            return View(productImages);
        }
    }
}
