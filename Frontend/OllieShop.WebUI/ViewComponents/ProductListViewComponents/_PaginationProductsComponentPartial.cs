using Microsoft.AspNetCore.Mvc;

namespace OllieShop.WebUI.ViewComponents.ProductListViewComponents
{
    public class _PaginationProductsComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
