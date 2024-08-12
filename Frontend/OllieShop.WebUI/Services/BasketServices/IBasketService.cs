using OllieShop.DtoLayer.BasketDtos;

namespace OllieShop.WebUI.Services.BasketServices
{
    public interface IBasketService
    {
        Task<BasketTotalDto> GetBasket();
        Task<HttpResponseMessage> SaveBasket(BasketTotalDto basketTotalDto);
        Task<HttpResponseMessage> DeleteBasket();
        Task<HttpResponseMessage> AddItemToBasket(BasketItemDto basketItemDto);
        Task<HttpResponseMessage> RemoveItemFromBasket(string productId);
        Task<BasketItemDto> UpdateBasketItem(string productId, int quantity, string sizeId ,string colorId);
    }
}
