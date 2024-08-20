using Microsoft.AspNetCore.Mvc;
using OllieShop.WebUI.Services.IUserService;

namespace OllieShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Users")]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [Route("Index")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var users = await _userService.GetUserListAsync();

            // 1. Toplam Kullanıcı Sayısı
            var totalUserCount = users.Count();

            // 2. Erkek Kullanıcı Sayısı
            var maleCount = users.Count(u => u.Gender == "Male");

            // 3. Yaş Ortalaması (Doğum tarihi mevcut olan kullanıcılar için)
            var averageAge = users
                .Where(u => u.DateOfBirth.HasValue)
                .Select(u => DateTime.Now.Year - u.DateOfBirth!.Value.Year)
                .Average();

            // 4. Kadın Kullanıcı Sayısı
            var femaleCount = users.Count(u => u.Gender == "Female");

            // ViewBag atamaları
            ViewBag.One = "Total Users";
            ViewBag.OneDesc = totalUserCount.ToString();
            ViewBag.OneIcon = "bx bx-user bx-lg text-success p-3";

            ViewBag.Two = "Male Users";
            ViewBag.TwoDesc = maleCount.ToString();
            ViewBag.TwoIcon = "bx bx-male bx-lg text-info p-3";

            ViewBag.Three = "Avg Age";
            ViewBag.ThreeDesc = averageAge.ToString("F1");
            ViewBag.ThreeIcon = "bx bx-calendar bx-lg text-warning p-3";

            ViewBag.Four = "Female Users";
            ViewBag.FourDesc = femaleCount.ToString();
            ViewBag.FourIcon = "bx bx-female bx-lg text-primary p-3";

            return View(users);
        }


    }
}
