using Microsoft.AspNetCore.Mvc;

namespace OllieShop.WebUI.ViewComponents.UILayoutViewComponents
{
    public class _ScriptsUILayoutComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
