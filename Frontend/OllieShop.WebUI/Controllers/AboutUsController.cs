using Microsoft.AspNetCore.Mvc;

namespace OllieShop.WebUI.Controllers
{
    public class AboutUsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
