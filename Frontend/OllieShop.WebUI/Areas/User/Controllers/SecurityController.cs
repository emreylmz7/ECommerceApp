using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OllieShop.DtoLayer.IdentityDtos;
using OllieShop.WebUI.Services.IdentityServices;
using OllieShop.WebUI.Services.IUserService;

namespace OllieShop.WebUI.Areas.User.Controllers
{
    [Authorize]
    [Area("User")]
    [Route("User/Security")]
    public class SecurityController : Controller
    {
        private readonly IUserService _userService;
        private readonly IIdentityService _identityService;
        public SecurityController(IUserService userService, IIdentityService identityService)
        {
            _userService = userService;
            _identityService = identityService;
        }

        [Route("Index")]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [Route("ChangePassword")]
        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordDto model)
        {
            var user = await _userService.GetUserInfoAsync();
            model.UserId = user.Id;

            var result = await _userService.ChangePasswordAsync(new ChangePasswordDto
            {
                UserId = model.UserId,
                CurrentPassword = model.CurrentPassword,
                NewPassword = model.NewPassword
            });

            if (result)
            {
                TempData["SuccessMessage"] = "Password changed successfully!";
                return Redirect("/User/Profile/Index");
            }

            TempData["ErrorMessage"] = "Failed to change password.";
            return View(model);
        }

        [Route("DeleteAccount")]
        [HttpPost]
        public async Task<IActionResult> DeleteAccount()
        {
            var user = await _userService.GetUserInfoAsync();
            var result = await _userService.DeleteUserAsync(user.Id);

            if (result)
            {
                await _identityService.LogOut();
                TempData["SuccessMessage"] = "Account deleted successfully!";
                return Redirect("/Default/Index");
            }

            TempData["ErrorMessage"] = "Failed to delete account.";
            return View();
        }
    }
}
