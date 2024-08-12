using Microsoft.AspNetCore.Mvc;

namespace OllieShop.WebUI.Areas.User.Controllers
{
    public class NotificationsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
