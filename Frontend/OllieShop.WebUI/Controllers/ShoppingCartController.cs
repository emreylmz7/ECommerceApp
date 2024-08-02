using Microsoft.AspNetCore.Mvc;
using OllieShop.DtoLayer.BasketDtos;
using OllieShop.WebUI.Services.BasketServices;
using OllieShop.WebUI.Services.CatalogServices.ProductServices;

namespace OllieShop.WebUI.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IProductService _productService;
        private readonly IBasketService _basketService;
        public ShoppingCartController(IProductService productService, IBasketService basketService)
        {
            _productService = productService;
            _basketService = basketService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _basketService.GetBasket();
            return View(values);
        }

        public async Task<IActionResult> AddItemToBasket(string productId)
        {
            var product = await _productService.GetByIdProductAsync(productId);
            if (product != null)
            {
                await _basketService.AddItemToBasket(new BasketItemDto
                {
                    ProductId = product.ProductId!,
                    Description = product.Description!,
                    ImageUrl = product.ImageUrl!,
                    ProductName = product.Name!,
                    Quantity = 1,
                    UnitPrice = product.Price
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

        public async Task<IActionResult> UpdateItemQuantity(string productId, int quantity)
        {
            var updatedItem = await _basketService.UpdateBasketItem(productId,quantity);
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
