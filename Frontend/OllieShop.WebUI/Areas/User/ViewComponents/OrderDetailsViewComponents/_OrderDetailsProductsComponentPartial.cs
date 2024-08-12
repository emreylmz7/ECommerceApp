using Microsoft.AspNetCore.Mvc;
using OllieShop.WebUI.Services.OrderServices.OrderDetailServices;

namespace OllieShop.WebUI.Areas.User.ViewComponents.OrderDetailsViewComponents
{
    public class _OrderDetailsProductsComponentPartial:ViewComponent
    {
        private readonly IOrderDetailService _orderDetailService;

        public _OrderDetailsProductsComponentPartial(IOrderDetailService orderDetailService)
        {
            _orderDetailService = orderDetailService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var orderDetails = await _orderDetailService.GetOrderDetailsByOrderingIdAsync(id);  
            return View(orderDetails);
        }
    }
}
