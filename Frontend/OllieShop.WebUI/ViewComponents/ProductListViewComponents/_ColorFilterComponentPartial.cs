using Microsoft.AspNetCore.Mvc;

namespace OllieShop.WebUI.ViewComponents.ProductListViewComponents
{
    public class _ColorFilterComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
