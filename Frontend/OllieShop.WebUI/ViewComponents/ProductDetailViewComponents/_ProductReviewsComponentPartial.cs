using Microsoft.AspNetCore.Mvc;
using OllieShop.WebUI.Services.CommentServices;
using OllieShop.WebUI.Services.IUserService;

namespace OllieShop.WebUI.ViewComponents.ProductDetailViewComponents
{
    public class _ProductReviewsComponentPartial : ViewComponent
    {
        private readonly IUserService _userService;
        private readonly ICommentService _commentService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public _ProductReviewsComponentPartial(IUserService userService, IHttpContextAccessor httpContextAccessor,ICommentService commentService)
        {
            _commentService = commentService;
            _userService = userService;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            ViewBag.ProductId = id;
            var comments = await _commentService.GetCommentsByProductId(id);
            var accessToken = _httpContextAccessor.HttpContext?.Request.Cookies["OllieShopCookie"];
            bool isLoggedIn = !string.IsNullOrEmpty(accessToken);

            // Eğer kullanıcı giriş yapmamışsa
            if (!isLoggedIn)
            {
                ViewData["IsLoggedIn"] = false;
                return View(comments);
            }

            ViewData["userInfo"] = await _userService.GetUserInfoAsync();
            ViewData["IsLoggedIn"] = true;

            return View(comments);
        }

    }
}
