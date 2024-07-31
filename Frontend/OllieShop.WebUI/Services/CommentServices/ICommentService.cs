using OllieShop.DtoLayer.CommentDtos;

namespace OllieShop.WebUI.Services.CommentServices
{
    public interface ICommentService
    {
        Task<List<ResultCommentDto>> GetAllCommentAsync();
        Task<HttpResponseMessage> CreateCommentAsync(CreateCommentDto createCommentDto);
        Task<HttpResponseMessage> UpdateCommentAsync(UpdateCommentDto updateCommentDto);
        Task<HttpResponseMessage> DeleteCommentAsync(string id);
        Task<GetByIdCommentDto> GetByIdCommentAsync(string id);
        Task<List<ResultCommentDto>> GetCommentsByProductId(string id);
        Task<RateStatisticsDto> GetRateStatisticsByProductId(string id);
    }
}
