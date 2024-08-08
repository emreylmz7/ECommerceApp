using Microsoft.AspNetCore.Mvc;
using OllieShop.DtoLayer.BasketDtos;
using OllieShop.WebUI.Services.BasketServices;
using OllieShop.WebUI.Services.CatalogServices.ColorServices;
using OllieShop.WebUI.Services.CatalogServices.ProductServices;
using OllieShop.WebUI.Services.CatalogServices.SizeServices;
using OllieShop.WebUI.Services.CouponServices;
using System.Reflection;

namespace OllieShop.WebUI.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IProductService _productService;
        private readonly IBasketService _basketService;
        private readonly ISizeService _sizeService;
        private readonly IColorService _colorService;
        private readonly ICouponService _couponService;
        public ShoppingCartController(IProductService productService, IBasketService basketService, ISizeService sizeService, IColorService colorService,ICouponService couponService)
        {
            _couponService = couponService;
            _productService = productService;
            _basketService = basketService;
            _sizeService = sizeService;
            _colorService = colorService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = await _basketService.GetBasket();
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> AddItemToBasket(string productId,string sizeId,string colorId)
        {
            if(!User.Identity!.IsAuthenticated)
            {
                return RedirectToAction("Index","Login");
            }
            var product = await _productService.GetByIdProductAsync(productId);
            var size = await _sizeService.GetByIdSizeAsync(sizeId);
            var color = await _colorService.GetByIdColorAsync(colorId);

            if (product != null)
            {
                await _basketService.AddItemToBasket(new BasketItemDto
                {
                    ProductId = product.ProductId!,
                    Description = product.Description!,
                    ImageUrl = product.ImageUrl!,
                    ProductName = product.Name!,
                    Quantity = 1,
                    UnitPrice = product.Price,
                    Color = color.Name,
                    ColorId = color.ColorId,
                    Size = size.Name,
                    SizeId = size.SizeId
                });

                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> RemoveItemFromBasket(string productId)
        {
            await _basketService.RemoveItemFromBasket(productId);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateItemQuantity(string productId, int quantity, string sizeId, string colorId)
        {
            var updatedItem = await _basketService.UpdateBasketItem(productId, quantity, sizeId, colorId);
            var basket = await _basketService.GetBasket();

            var totalPrice = basket.TotalPrice; // ÜRÜNLERİN TUTARI
            var totalDiscountedPriceWithShipping = basket.TotalDiscountedPriceWithShipping; // GENEL TOTAL
            var discountAmount = (basket.TotalPriceWithVAT / 100) * basket.DiscountRate; // İNDİRİM TUTARI   
            var vatPrice = (basket.TotalPrice * basket.VATRate); // KDV TUTARI

            return Json(new { updatedItem, totalPrice, discountAmount, vatPrice, totalDiscountedPriceWithShipping });
        }


        [HttpPost]
        public async Task<IActionResult> ApplyCouponToBasket(string discountCode)
        {
            if (string.IsNullOrEmpty(discountCode))
            {
                TempData["ErrorMessage"] = "Coupon code cannot be empty.";
                return RedirectToAction("Index", "ShoppingCart");
            }

            var basket = await _basketService.GetBasket();

            if (basket == null)
            {
                TempData["ErrorMessage"] = "Basket not found.";
                return RedirectToAction("Index", "ShoppingCart");
            }

            var coupons = await _couponService.GetAllCouponAsync();
            var coupon = coupons.FirstOrDefault(x => x.Code == discountCode);

            if (coupon == null)
            {
                TempData["ErrorMessage"] = "Invalid coupon code.";
                return RedirectToAction("Index", "ShoppingCart");
            }

            basket.DiscountCode = coupon.Code!;
            basket.DiscountRate = coupon.Rate;

            await _basketService.SaveBasket(basket);

            TempData["SuccessMessage"] = "Coupon applied successfully.";
            return RedirectToAction("Index", "ShoppingCart");
        }

        [HttpPost]
        public async Task<IActionResult> RemoveCouponFromBasket()
        {
            var basket = await _basketService.GetBasket();
            if (basket == null)
            {
                return Json(new { success = false, message = "Basket not found." });
            }

            basket.DiscountCode = "";
            basket.DiscountRate = 0;

            await _basketService.SaveBasket(basket);

            var totalPrice = basket.TotalPrice;
            var totalDiscountedPriceWithShipping = basket.TotalDiscountedPriceWithShipping;
            var discountAmount = (basket.TotalPriceWithVAT / 100) * basket.DiscountRate;
            var vatPrice = (basket.TotalPrice * basket.VATRate);

            return Json(new { success = true, totalPrice, discountAmount, vatPrice, totalDiscountedPriceWithShipping });
        }


    }
}
