using System.Text.Json;
using OllieShop.Basket.Dtos;
using OllieShop.Basket.Settings;

namespace OllieShop.Basket.Services
{
    public class BasketService : IBasketService
    {
        private readonly RedisService _redisService;

        public BasketService(RedisService redisService)
        {
            _redisService = redisService;
            _redisService.Connect();
        }

        public async Task DeleteBasket(string userId)
        {
            var db = _redisService.GetDb();
            await db.KeyDeleteAsync(userId);
        }

        public async Task<BasketTotalDto> GetBasket(string userId)
        {
            var db = _redisService.GetDb();
            var basketData = await db.StringGetAsync(userId);

            if (basketData.IsNullOrEmpty)
            {
                var newBasket = new BasketTotalDto
                {
                    UserId = userId,
                    BasketItems = new List<BasketItemDto>(),
                    DateCreated = DateTime.Now,
                    Currency = "USD",
                    DiscountCode = "",
                    DiscountRate = 0,
                    LastUpdated = DateTime.Now,
                };

                await SaveBasket(newBasket);

                return newBasket;
            }

            return JsonSerializer.Deserialize<BasketTotalDto>(basketData!)!;
        }

        public async Task SaveBasket(BasketTotalDto basketTotalDto)
        {
            var db = _redisService.GetDb();
            var basketData = JsonSerializer.Serialize(basketTotalDto);
            await db.StringSetAsync(basketTotalDto.UserId, basketData);
        }
    }
}
