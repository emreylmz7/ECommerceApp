using Microsoft.AspNetCore.Mvc;
using OllieShop.WebUI.Services.CatalogServices.ProductDetailServices;

namespace OllieShop.WebUI.ViewComponents.ProductDetailViewComponents
{
    public class _ProductDescriptionComponentPartial:ViewComponent
    {
        private readonly IProductDetailService _productDetailService;
        public _ProductDescriptionComponentPartial(IProductDetailService productDetailService)
        {
            _productDetailService = productDetailService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var productDetails = await _productDetailService.GetProductDetailsByProductId(id);
            return View(productDetails);
        }
    }
}
