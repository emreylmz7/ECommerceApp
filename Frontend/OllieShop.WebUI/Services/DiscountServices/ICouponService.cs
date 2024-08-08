using OllieShop.DtoLayer.DiscountDtos;

namespace OllieShop.WebUI.Services.CouponServices
{
    public interface ICouponService
    {
        Task<List<ResultCouponDto>> GetAllCouponAsync();
        Task<HttpResponseMessage> CreateCouponAsync(CreateCouponDto createCouponDto);
        Task<HttpResponseMessage> UpdateCouponAsync(UpdateCouponDto updateCouponDto);
        Task<HttpResponseMessage> DeleteCouponAsync(string id);
        Task<GetByIdCouponDto> GetByIdCouponAsync(string id);
    }
}
