using OllieShop.DtoLayer.DiscountDtos;
using OllieShop.WebUI.Services.CouponServices;

namespace OllieShop.WebUI.Services.CatalogServices.CouponServices
{
    public class CouponService : ICouponService
    {
        private readonly HttpClient _httpClient;

        public CouponService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> CreateCouponAsync(CreateCouponDto createCouponDto)
        {
            var responseMessage = await _httpClient.PostAsJsonAsync("discounts", createCouponDto);
            responseMessage.EnsureSuccessStatusCode();
            return responseMessage;
        }

        public async Task<HttpResponseMessage> DeleteCouponAsync(string id)
        {
            var responseMessage = await _httpClient.DeleteAsync($"discounts?id={id}");
            responseMessage.EnsureSuccessStatusCode();
            return responseMessage;
        }

        public async Task<List<ResultCouponDto>> GetAllCouponAsync()
        {
            var responseMessage = await _httpClient.GetAsync("discounts");
            if (responseMessage.IsSuccessStatusCode)
            {
                var coupons = await responseMessage.Content.ReadFromJsonAsync<List<ResultCouponDto>>();
                return coupons ?? new List<ResultCouponDto>();
            }
            return new List<ResultCouponDto>();
        }

        public async Task<GetByIdCouponDto?> GetByIdCouponAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync($"discounts/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var coupon = await responseMessage.Content.ReadFromJsonAsync<GetByIdCouponDto>();
                return coupon;
            }
            return null;
        }

        public async Task<HttpResponseMessage> UpdateCouponAsync(UpdateCouponDto updateCouponDto)
        {
            var responseMessage = await _httpClient.PutAsJsonAsync("discounts", updateCouponDto);
            responseMessage.EnsureSuccessStatusCode();
            return responseMessage;
        }
    }
}
