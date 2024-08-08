
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
            var responseMessage = await _httpClient.PostAsJsonAsync<CreateCouponDto>("discounts", createCouponDto);
            return responseMessage;
        }

        public async Task<HttpResponseMessage> DeleteCouponAsync(string id)
        {
            var responseMessage = await _httpClient.DeleteAsync($"discounts?id={id}");
            return responseMessage;
        }

        public async Task<List<ResultCouponDto>> GetAllCouponAsync()
        {
            var responseMessage = await _httpClient.GetAsync("discounts");
            var coupons = await responseMessage.Content.ReadFromJsonAsync<List<ResultCouponDto>>();
            return coupons ?? new List<ResultCouponDto>();
        }

        public async Task<GetByIdCouponDto> GetByIdCouponAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync($"discounts/{id}");
            var coupon = await responseMessage.Content.ReadFromJsonAsync<GetByIdCouponDto>();
            return coupon;
        }

        public async Task<HttpResponseMessage> UpdateCouponAsync(UpdateCouponDto updateCouponDto)
        {
            var responseMessage = await _httpClient.PutAsJsonAsync<UpdateCouponDto>("discounts", updateCouponDto);
            return responseMessage;
        }
    }
}
