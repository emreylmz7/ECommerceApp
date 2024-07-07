using Microsoft.AspNetCore.Mvc;

namespace OllieShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class _RecentProductsDefaultComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
