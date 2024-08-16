using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OllieShop.Message.Dtos;
using OllieShop.Message.Dal.Context;
using OllieShop.Message.Dal.Entitites;
using System.Security.Claims;

namespace OllieShop.Message.Services
{
    public class UserMessageService : IUserMessageService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly MessageContext _context;
        private readonly IMapper _mapper;

        public UserMessageService(IHttpContextAccessor httpContextAccessor, MessageContext context, IMapper mapper)
        {
            _httpContextAccessor = httpContextAccessor;
            _context = context;
            _mapper = mapper;
        }

        private string GetCurrentUserId()
        {
            return _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value
                   ?? throw new InvalidOperationException("User ID not found in claims.");
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
            var userId = GetCurrentUserId();
            var messages = await _context.Messages
                .AsNoTracking()
                .Where(x => x.SenderId == userId || x.ReceiverId == userId)
                .ToListAsync();

            return _mapper.Map<List<ResultMessageDto>>(messages);
        }

        public async Task<List<ResultInboxMessageDto>> GetInboxMessagesAsync()
        {
            var userId = GetCurrentUserId();
            var messages = await _context.Messages
                .AsNoTracking()
                .Where(m => m.ReceiverId == userId)
                .ToListAsync();

            return _mapper.Map<List<ResultInboxMessageDto>>(messages);
        }

        public async Task<GetByIdMessageDto> GetMessageByIdAsync(int id)
        {
            var message = await _context.Messages
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.MessageId == id);

            return _mapper.Map<GetByIdMessageDto>(message);
        }

        public async Task<List<ResultSendBoxMessageDto>> GetSendboxMessagesAsync()
        {
            var userId = GetCurrentUserId();
            var messages = await _context.Messages
                .AsNoTracking()
                .Where(m => m.SenderId == userId)
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
