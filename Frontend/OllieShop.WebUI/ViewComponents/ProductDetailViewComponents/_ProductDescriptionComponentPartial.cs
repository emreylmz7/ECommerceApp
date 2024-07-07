using Microsoft.AspNetCore.Mvc;

namespace OllieShop.WebUI.ViewComponents.ProductDetailViewComponents
{
    public class _ProductDescriptionComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
