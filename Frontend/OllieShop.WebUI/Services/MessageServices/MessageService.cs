using OllieShop.DtoLayer.MessageDtos;

namespace OllieShop.WebUI.Services.MessageServices
{
    public class MessageService : IMessageService
    {
        private readonly HttpClient _httpClient;

        public MessageService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateMessageAsync(CreateMessageDto createMessageDto)
        {
            var response = await _httpClient.PostAsJsonAsync("messages", createMessageDto);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteMessageAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"messages/{id}");
            response.EnsureSuccessStatusCode();
        }

        public async Task<List<ResultMessageDto>> GetAllMessagesAsync()
        {
            var responseMessage = await _httpClient.GetAsync("messages");
            if (responseMessage.IsSuccessStatusCode)
            {
                var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultMessageDto>>();
                return values ?? new List<ResultMessageDto>();
            }
            return new List<ResultMessageDto>();
        }

        public async Task<List<ResultInboxMessageDto>> GetInboxMessagesAsync()
        {
            var responseMessage = await _httpClient.GetAsync($"messages/inbox");
            if (responseMessage.IsSuccessStatusCode)
            {
                var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultInboxMessageDto>>();
                return values ?? new List<ResultInboxMessageDto>();
            }
            return new List<ResultInboxMessageDto>();
        }

        public async Task<GetByIdMessageDto> GetMessageByIdAsync(int id)
        {
            var responseMessage = await _httpClient.GetAsync($"messages/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var value = await responseMessage.Content.ReadFromJsonAsync<GetByIdMessageDto>();
                return value!;
            }
            return null!;
        }

        public async Task<List<ResultSendBoxMessageDto>> GetSendboxMessagesAsync()
        {
            var responseMessage = await _httpClient.GetAsync($"messages/sendbox");
            if (responseMessage.IsSuccessStatusCode)
            {
                var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultSendBoxMessageDto>>();
                return values ?? new List<ResultSendBoxMessageDto>();
            }
            return new List<ResultSendBoxMessageDto>();
        }

        public async Task UpdateMessageAsync(UpdateMessageDto updateMessageDto)
        {
            var response = await _httpClient.PutAsJsonAsync("messages", updateMessageDto);
            response.EnsureSuccessStatusCode();
        }
    }
}
