using Microsoft.AspNetCore.Mvc;
using OllieShop.WebUI.Services.CatalogServices.ProductImageServices;

namespace OllieShop.WebUI.Areas.Admin.ViewComponents.ProductImagesViewComponents
{
    public class _ProductImagesUpdateComponentPartial : ViewComponent
    {
        private readonly IProductImageService _productImageService;

        public _ProductImagesUpdateComponentPartial(IProductImageService productImageService)
        {
            _productImageService = productImageService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var productImages = await _productImageService.GetProductImagesByProductId(id);
            return View(productImages);
        }
    }
}
