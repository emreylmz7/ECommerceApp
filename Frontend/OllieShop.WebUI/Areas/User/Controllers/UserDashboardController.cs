using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace OllieShop.WebUI.Areas.User.Controllers
{
    [Authorize]
    [Area("User")]
    [Route("User/UserDashboard")]
    public class UserDashboardController : Controller
    {
        [Route("Index")]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
