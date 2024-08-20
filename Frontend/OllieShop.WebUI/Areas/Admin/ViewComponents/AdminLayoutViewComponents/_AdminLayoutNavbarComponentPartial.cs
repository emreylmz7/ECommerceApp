using Microsoft.AspNetCore.Mvc;
using OllieShop.WebUI.Services.IUserService;

namespace OllieShop.WebUI.Areas.Admin.ViewComponents.AdminLayoutViewComponents
{
    public class _AdminLayoutNavbarComponentPartial:ViewComponent
    {
        private readonly IUserService _userService;
        public _AdminLayoutNavbarComponentPartial(IUserService userService)
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
