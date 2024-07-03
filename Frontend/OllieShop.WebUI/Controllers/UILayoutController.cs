using Microsoft.AspNetCore.Mvc;

namespace OllieShop.WebUI.Controllers
{
    public class UILayoutController : Controller
    {
        public IActionResult _UILayout()
        {
            return View();
        }
    }
}
