using Microsoft.AspNetCore.Mvc;

namespace OllieShop.WebUI.Areas.Admin.ViewComponents.CatalogStatisticsViewComponents
{
    public class _TopLayerStatisticsComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
