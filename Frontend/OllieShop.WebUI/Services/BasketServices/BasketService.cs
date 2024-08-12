using OllieShop.DtoLayer.BasketDtos;

namespace OllieShop.WebUI.Services.BasketServices
{
    public class BasketService : IBasketService
    {
        private readonly HttpClient _httpClient;

        public BasketService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> AddItemToBasket(BasketItemDto basketItemDto)
        {
            var values = await GetBasket();
            if (values != null)
            {
                var existingItem = values.BasketItems.FirstOrDefault(x => x.ProductId == basketItemDto.ProductId && x.SizeId == basketItemDto.SizeId && x.ColorId == basketItemDto.ColorId);
                if (existingItem == null)
                {
                    values.BasketItems.Add(basketItemDto);
                }
                else
                {
                    existingItem.Quantity += basketItemDto.Quantity;
                }
            }
            else
            {
                values = new BasketTotalDto();
                values.BasketItems.Add(basketItemDto);
            }
            return await SaveBasket(values);
        }

        public async Task<HttpResponseMessage> DeleteBasket()
        {
            var response = await _httpClient.DeleteAsync("baskets");
            return response;
        }

        public async Task<BasketTotalDto> GetBasket()
        {
            var responseMessage = await _httpClient.GetAsync("baskets");
            var values = await responseMessage.Content.ReadFromJsonAsync<BasketTotalDto>();
            return values!;
        }

        public async Task<HttpResponseMessage> RemoveItemFromBasket(string productId)
        {
            var values = await GetBasket();
            if (values != null)
            {
                var itemToRemove = values.BasketItems.FirstOrDefault(x => x.ProductId == productId);
                if (itemToRemove != null)
                {
                    values.BasketItems.Remove(itemToRemove);
                }
            }
            return await SaveBasket(values);
        }

        public async Task<HttpResponseMessage> SaveBasket(BasketTotalDto basketTotalDto)
        {
            var response = await _httpClient.PostAsJsonAsync<BasketTotalDto>("baskets", basketTotalDto);
            return response;
        }

        public async Task<BasketItemDto> UpdateBasketItem(string productId, int quantity, string sizeId, string colorId)
        {
            var values = await GetBasket();
            var existingItem = new BasketItemDto();
            if (values != null)
            {
                existingItem = values.BasketItems.FirstOrDefault(x => x.ProductId == productId && x.SizeId == sizeId && x.ColorId == colorId);
                if (existingItem != null)
                {
                    existingItem.Quantity = quantity;
                }
            }
            await SaveBasket(values!);
            return existingItem!;
        }
    }
}
