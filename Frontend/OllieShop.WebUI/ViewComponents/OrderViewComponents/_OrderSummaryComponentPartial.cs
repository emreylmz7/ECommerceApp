using Microsoft.AspNetCore.Mvc;
using OllieShop.WebUI.Services.BasketServices;

namespace OllieShop.WebUI.ViewComponents.OrderViewComponents
{
    public class _OrderSummaryComponentPartial:ViewComponent
    {
        private readonly IBasketService _basketService;

        public _OrderSummaryComponentPartial(IBasketService basketService)
        {
            _basketService = basketService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var basket = await _basketService.GetBasket();
            return View(basket);
        }
    }
}
