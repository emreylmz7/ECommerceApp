using Microsoft.AspNetCore.Mvc;
using OllieShop.DtoLayer.PaymentDtos;

namespace OllieShop.WebUI.Controllers
{
    public class PaymentController : Controller
    {
        public IActionResult Index(string orderId)
        {
            ViewBag.OrderId = orderId;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreatePaymentDto createPaymentDto)
        {
            return View();
        }
    }
}
