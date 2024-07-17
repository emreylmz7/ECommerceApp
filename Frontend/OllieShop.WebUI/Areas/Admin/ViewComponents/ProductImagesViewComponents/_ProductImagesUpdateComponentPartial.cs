using Microsoft.AspNetCore.Mvc;
using OllieShop.DtoLayer.CatalogDtos.ProductImage;
using OllieShop.WebUI.Services.ApiServices;

namespace OllieShop.WebUI.Areas.Admin.ViewComponents.ProductImagesViewComponents
{
    public class _ProductImagesUpdateComponentPartial : ViewComponent
    {
        private readonly IApiService _apiService;
        public _ProductImagesUpdateComponentPartial(IApiService apiService)
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
