using Microsoft.AspNetCore.Mvc;

namespace OllieShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class _OfferDefaultComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
