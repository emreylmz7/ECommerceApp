using Microsoft.AspNetCore.Mvc;
using OllieShop.DtoLayer.BasketDtos;
using OllieShop.WebUI.Services.BasketServices;
using OllieShop.WebUI.Services.CatalogServices.ColorServices;
using OllieShop.WebUI.Services.CatalogServices.ProductServices;
using OllieShop.WebUI.Services.CatalogServices.SizeServices;

namespace OllieShop.WebUI.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IProductService _productService;
        private readonly IBasketService _basketService;
        private readonly ISizeService _sizeService;
        private readonly IColorService _colorService;
        public ShoppingCartController(IProductService productService, IBasketService basketService, ISizeService sizeService, IColorService colorService)
        {
            _productService = productService;
            _basketService = basketService;
            _sizeService = sizeService;
            _colorService = colorService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _basketService.GetBasket();
            return View(values);
        }

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

        public async Task<IActionResult> RemoveItemFromBasket(string productId)
        {
            await _basketService.RemoveItemFromBasket(productId);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateItemQuantity(string productId, int quantity, string sizeId, string colorId)
        {
            var updatedItem = await _basketService.UpdateBasketItem(productId,quantity,sizeId,colorId);
            var totalPrice = await CalculateTotalPrice();
            return Json(new { updatedItem, totalPrice });
        }

        private async Task<decimal> CalculateTotalPrice()
        {
            var basket = await _basketService.GetBasket();
            decimal totalPrice = 0;
            foreach (var item in basket.BasketItems)
            {
                totalPrice += item.Quantity*item.UnitPrice;
            }
            
            return totalPrice;
        }
    }
}
