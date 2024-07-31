using OllieShop.DtoLayer.CommentDtos;
using OllieShop.WebUI.Services.CommentServices;
using System.Net;

namespace OllieShop.WebUI.Services.CatalogServices.CommentServices
{
    public class CommentService : ICommentService
    {
        private readonly HttpClient _httpClient;

        public CommentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> CreateCommentAsync(CreateCommentDto createCommentDto)
        {
            var responseMessage = await _httpClient.PostAsJsonAsync<CreateCommentDto>("comments", createCommentDto);
            return responseMessage;
        }

        public async Task<HttpResponseMessage> DeleteCommentAsync(string id)
        {
            var responseMessage = await _httpClient.DeleteAsync($"comments?id={id}");
            return responseMessage;
        }

        public async Task<List<ResultCommentDto>> GetAllCommentAsync()
        {
            var responseMessage = await _httpClient.GetAsync("comments");
            var comments = await responseMessage.Content.ReadFromJsonAsync<List<ResultCommentDto>>();
            return comments ?? new List<ResultCommentDto>();
        }

        public async Task<GetByIdCommentDto> GetByIdCommentAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync($"comments/{id}");
            var comment = await responseMessage.Content.ReadFromJsonAsync<GetByIdCommentDto>();
            return comment;
        }

        public async Task<List<ResultCommentDto>> GetCommentsByProductId(string id)
        {
            var responseMessage = await _httpClient.GetAsync($"Comments/GetCommentsByProductId?productId={id}");
            if (responseMessage.StatusCode == HttpStatusCode.NotFound)
            {
                return new List<ResultCommentDto>();
            }
            var comments = await responseMessage.Content.ReadFromJsonAsync<List<ResultCommentDto>>();
            return comments!;
        }

        public async Task<RateStatisticsDto> GetRateStatisticsByProductId(string id)
        {
            var responseMessage = await _httpClient.GetAsync($"Comments/GetRatesByProductId?productId={id}");
            if (responseMessage.StatusCode == HttpStatusCode.NotFound)
            {
                return new RateStatisticsDto
                {
                    AverageRate = 0,
                    TotalComments = 0,
                };
            }
            var rateStatistics = await responseMessage.Content.ReadFromJsonAsync<RateStatisticsDto>();
            return rateStatistics!;
        }

        public async Task<HttpResponseMessage> UpdateCommentAsync(UpdateCommentDto updateCommentDto)
        {
            var responseMessage = await _httpClient.PutAsJsonAsync<UpdateCommentDto>("comments", updateCommentDto);
            return responseMessage;
        }
    }
}
