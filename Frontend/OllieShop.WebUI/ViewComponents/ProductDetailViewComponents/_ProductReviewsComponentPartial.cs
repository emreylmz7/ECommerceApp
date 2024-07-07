using Microsoft.AspNetCore.Mvc;

namespace OllieShop.WebUI.ViewComponents.ProductDetailViewComponents
{
    public class _ProductReviewsComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
