using Microsoft.AspNetCore.Mvc;
using OllieShop.WebUI.Services.BasketServices;
using OllieShop.WebUI.Services.CatalogServices.CategoryServices;

namespace OllieShop.WebUI.ViewComponents.UILayoutViewComponents
{
    public class _NavbarUILayoutComponentPartial : ViewComponent
    {
        private readonly ICategoryService _categoryService;
        private readonly IBasketService _basketService;
        public _NavbarUILayoutComponentPartial(ICategoryService categoryService, IBasketService basketService)
        {
            _basketService = basketService;
            _categoryService = categoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            if (User.Identity!.IsAuthenticated)
            {
                ViewBag.BasketCount = await _basketService.BasketTotalCount();
            }
            var categories = await _categoryService.GetAllCategoryAsync();
            return View(categories);
        }
    }
}
