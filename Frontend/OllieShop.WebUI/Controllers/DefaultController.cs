using Microsoft.AspNetCore.Mvc;

namespace OllieShop.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
