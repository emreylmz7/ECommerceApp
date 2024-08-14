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
            var responseMessage = await _httpClient.PostAsJsonAsync("comments", createCommentDto);
            responseMessage.EnsureSuccessStatusCode();
            return responseMessage;
        }

        public async Task<HttpResponseMessage> DeleteCommentAsync(string id)
        {
            var responseMessage = await _httpClient.DeleteAsync($"comments?id={id}");
            responseMessage.EnsureSuccessStatusCode();
            return responseMessage;
        }

        public async Task<List<ResultCommentDto>> GetAllCommentAsync()
        {
            var responseMessage = await _httpClient.GetAsync("comments");
            if (responseMessage.IsSuccessStatusCode)
            {
                var comments = await responseMessage.Content.ReadFromJsonAsync<List<ResultCommentDto>>();
                return comments ?? new List<ResultCommentDto>();
            }
            return new List<ResultCommentDto>();
        }

        public async Task<GetByIdCommentDto?> GetByIdCommentAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync($"comments/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var comment = await responseMessage.Content.ReadFromJsonAsync<GetByIdCommentDto>();
                return comment;
            }
            return null;
        }

        public async Task<List<ResultCommentDto>> GetCommentsByProductId(string id)
        {
            var responseMessage = await _httpClient.GetAsync($"Comments/GetCommentsByProductId?productId={id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var comments = await responseMessage.Content.ReadFromJsonAsync<List<ResultCommentDto>>();
                return comments ?? new List<ResultCommentDto>();
            }
            return new List<ResultCommentDto>();
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
            if (responseMessage.IsSuccessStatusCode)
            {
                var rateStatistics = await responseMessage.Content.ReadFromJsonAsync<RateStatisticsDto>();
                return rateStatistics ?? new RateStatisticsDto
                {
                    AverageRate = 0,
                    TotalComments = 0,
                };
            }
            return new RateStatisticsDto
            {
                AverageRate = 0,
                TotalComments = 0,
            };
        }

        public async Task<HttpResponseMessage> UpdateCommentAsync(UpdateCommentDto updateCommentDto)
        {
            var responseMessage = await _httpClient.PutAsJsonAsync("comments", updateCommentDto);
            responseMessage.EnsureSuccessStatusCode();
            return responseMessage;
        }
    }
}
