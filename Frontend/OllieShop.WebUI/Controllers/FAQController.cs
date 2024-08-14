using Microsoft.AspNetCore.Mvc;

namespace OllieShop.WebUI.Controllers
{
    public class FAQController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
