using Microsoft.AspNetCore.Mvc;
using OllieShop.DtoLayer.DiscountDtos;
using OllieShop.WebUI.Services.CatalogServices.CouponServices;
using OllieShop.WebUI.Services.CouponServices;

namespace OllieShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Coupon")]
    public class CouponController : Controller
    {
        private readonly ICouponService _couponService;

        public CouponController(ICouponService couponService)
        {
            _couponService = couponService;
        }

        [Route("Index")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var coupons = await _couponService.GetAllCouponAsync();
            return View(coupons);
        }

        [Route("CreateCoupon")]
        [HttpGet]
        public IActionResult CreateCoupon()
        {
            return View();
        }

        [HttpPost]
        [Route("CreateCoupon")]
        public async Task<IActionResult> CreateCoupon(CreateCouponDto createCouponDto)
        {
            var responseMessage = await _couponService.CreateCouponAsync(createCouponDto);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Coupon", new { area = "Admin" });
            }
            return View();
        }

        [Route("DeleteCoupon/{id}")]
        [HttpGet]
        public async Task<IActionResult> DeleteCoupon(string id)
        {
            var responseMessage = await _couponService.DeleteCouponAsync(id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Coupon", new { area = "Admin" });
            }
            return View();
        }

        [Route("UpdateCoupon/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateCoupon(string id)
        {
            var coupon = await _couponService.GetByIdCouponAsync(id);
            var couponDto = new UpdateCouponDto
            {
                CouponId = coupon.CouponId,
                Code = coupon.Code,
                IsActive = coupon.IsActive, 
                Rate = coupon.Rate,
                ValidDate = coupon.ValidDate,
            };
            return View(couponDto);
        }

        [HttpPost]
        [Route("UpdateCoupon/{id}")]
        public async Task<IActionResult> UpdateCoupon(UpdateCouponDto updateCouponDto)
        {
            var responseMessage = await _couponService.UpdateCouponAsync(updateCouponDto);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Coupon", new { area = "Admin" });
            }
            return View();
        }
    }
}
