using OllieShop.DtoLayer.MessageDtos;

namespace OllieShop.WebUI.Services.MessageServices
{
    public interface IMessageService
    {
        Task<List<ResultMessageDto>> GetAllMessagesAsync();

        // Belirli bir kullanıcıya/alıcıya ait gelen mesajları (Inbox) getirir
        Task<List<ResultInboxMessageDto>> GetInboxMessagesAsync();

        // Belirli bir kullanıcıya/göndericiye ait gönderilen mesajları (Sendbox) getirir
        Task<List<ResultSendBoxMessageDto>> GetSendboxMessagesAsync();

        Task CreateMessageAsync(CreateMessageDto createMessageDto);

        Task UpdateMessageAsync(UpdateMessageDto updateMessageDto);

        Task DeleteMessageAsync(int id);

        Task<GetByIdMessageDto> GetMessageByIdAsync(int id);
    }
}
