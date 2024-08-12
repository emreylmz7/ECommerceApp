using Microsoft.AspNetCore.Mvc;

namespace OllieShop.WebUI.Areas.User.Controllers
{
    public class WishListController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
