using Microsoft.AspNetCore.Mvc;
using OllieShop.WebUI.Services.OrderServices.OrderingServices;

namespace OllieShop.WebUI.Areas.User.ViewComponents.UserDashboardViewComponents
{
    public class _LatestOrdersComponentPartial:ViewComponent
    {
        private readonly IOrderingService _orderingService;
        public _LatestOrdersComponentPartial(IOrderingService orderingService)
        {
            _orderingService = orderingService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = (await _orderingService.GetOrderingsByUserAsync()).TakeLast(4).ToList();
            return View(values);
        }
    }
}
