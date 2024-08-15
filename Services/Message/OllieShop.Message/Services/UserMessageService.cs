using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OllieShop.Message.Dtos;
using OllieShop.Message.Dal.Context;
using OllieShop.Message.Dal.Entitites;

namespace OllieShop.Message.Services
{
    public class UserMessageService : IUserMessageService
    {
        private readonly MessageContext _context;
        private readonly IMapper _mapper;

        public UserMessageService(MessageContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreateMessageAsync(CreateMessageDto createMessageDto)
        {
            var message = _mapper.Map<Dal.Entitites.Message>(createMessageDto);
            message.SentAt = DateTime.UtcNow;
            message.IsRead = false;

            _context.Messages.Add(message);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMessageAsync(int id)
        {
            var message = await _context.Messages.FindAsync(id);
            if (message != null)
            {
                _context.Messages.Remove(message);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<ResultMessageDto>> GetAllMessagesAsync()
        {
            var messages = await _context.Messages.ToListAsync();
            return _mapper.Map<List<ResultMessageDto>>(messages);
        }

        public async Task<List<ResultInboxMessageDto>> GetInboxMessagesAsync(string receiverId)
        {
            var messages = await _context.Messages
                .Where(m => m.ReceiverId == receiverId)
                .ToListAsync();

            return _mapper.Map<List<ResultInboxMessageDto>>(messages);
        }

        public async Task<GetByIdMessageDto> GetMessageByIdAsync(int id)
        {
            var message = await _context.Messages.FindAsync(id);
            return _mapper.Map<GetByIdMessageDto>(message);
        }

        public async Task<List<ResultSendBoxMessageDto>> GetSendboxMessagesAsync(string senderId)
        {
            var messages = await _context.Messages
                .Where(m => m.SenderId == senderId)
                .ToListAsync();

            return _mapper.Map<List<ResultSendBoxMessageDto>>(messages);
        }

        public async Task UpdateMessageAsync(UpdateMessageDto updateMessageDto)
        {
            var message = await _context.Messages.FindAsync(updateMessageDto.MessageId);
            if (message != null)
            {
                _mapper.Map(updateMessageDto, message);
                _context.Messages.Update(message);
                await _context.SaveChangesAsync();
            }
        }
    }
}
