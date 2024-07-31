using Microsoft.AspNetCore.Mvc;
using OllieShop.WebUI.Services.CatalogServices.ProductServices;

namespace OllieShop.WebUI.ViewComponents.ProductDetailViewComponents
{
    public class _ProductPreviewComponentPartial: ViewComponent
    {
        private readonly IProductService _productService;
        public _ProductPreviewComponentPartial(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var product = await _productService.GetByIdProductAsync(id);
            return View(product);
        }
    }
}
