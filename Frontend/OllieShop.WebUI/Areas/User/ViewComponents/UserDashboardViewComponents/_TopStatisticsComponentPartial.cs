using Microsoft.AspNetCore.Mvc;
using OllieShop.WebUI.Services.OrderServices.OrderingServices;

namespace OllieShop.WebUI.Areas.User.ViewComponents.UserDashboardViewComponents
{
    public class _TopStatisticsComponentPartial:ViewComponent
    {
        private readonly IOrderingService _orderingService;
        public _TopStatisticsComponentPartial(IOrderingService orderingService)
        {
            _orderingService = orderingService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var orderStatistics = await _orderingService.GetOrderingStatisticsAsync();
            return View(orderStatistics);
        }
    }
}
