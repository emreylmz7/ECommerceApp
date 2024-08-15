using OllieShop.Message.Dtos;

namespace OllieShop.Message.Services
{
    public interface IUserMessageService
    {
        Task<List<ResultMessageDto>> GetAllMessagesAsync();

        // Belirli bir kullanıcıya/alıcıya ait gelen mesajları (Inbox) getirir
        Task<List<ResultInboxMessageDto>> GetInboxMessagesAsync(string receiverId);

        // Belirli bir kullanıcıya/göndericiye ait gönderilen mesajları (Sendbox) getirir
        Task<List<ResultSendBoxMessageDto>> GetSendboxMessagesAsync(string senderId);

        Task CreateMessageAsync(CreateMessageDto createMessageDto);

        Task UpdateMessageAsync(UpdateMessageDto updateMessageDto);

        Task DeleteMessageAsync(int id);

        Task<GetByIdMessageDto> GetMessageByIdAsync(int id);
    } 
}
