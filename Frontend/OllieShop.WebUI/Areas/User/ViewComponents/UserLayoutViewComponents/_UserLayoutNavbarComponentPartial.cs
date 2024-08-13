using Microsoft.AspNetCore.Mvc;
using OllieShop.WebUI.Services.IUserService;

namespace OllieShop.WebUI.Areas.User.ViewComponents.UserLayoutViewComponents
{
    public class _UserLayoutNavbarComponentPartial:ViewComponent
    {
        private readonly IUserService _userService;
        public _UserLayoutNavbarComponentPartial(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userService.GetUserInfoAsync();
            return View(user);
        }
    }
}
