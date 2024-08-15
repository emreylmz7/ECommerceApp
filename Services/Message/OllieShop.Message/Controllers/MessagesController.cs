using Microsoft.AspNetCore.Mvc;
using OllieShop.Message.Dtos;
using OllieShop.Message.Services;

namespace OllieShop.Message.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IUserMessageService _userMessageService;

        public MessagesController(IUserMessageService userMessageService)
        {
            _userMessageService = userMessageService;
        }

        // GET: api/messages
        [HttpGet]
        public async Task<ActionResult<List<ResultMessageDto>>> GetAllMessages()
        {
            var messages = await _userMessageService.GetAllMessagesAsync();
            return Ok(messages);
        }

        // GET: api/messages/inbox/{receiverId}
        [HttpGet("inbox/{receiverId}")]
        public async Task<ActionResult<List<ResultInboxMessageDto>>> GetInboxMessages(string receiverId)
        {
            var inboxMessages = await _userMessageService.GetInboxMessagesAsync(receiverId);
            return Ok(inboxMessages);
        }

        // GET: api/messages/sendbox/{senderId}
        [HttpGet("sendbox/{senderId}")]
        public async Task<ActionResult<List<ResultSendBoxMessageDto>>> GetSendboxMessages(string senderId)
        {
            var sendboxMessages = await _userMessageService.GetSendboxMessagesAsync(senderId);
            return Ok(sendboxMessages);
        }

        // GET: api/messages/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<GetByIdMessageDto>> GetMessageById(int id)
        {
            var message = await _userMessageService.GetMessageByIdAsync(id);
            if (message == null)
            {
                return NotFound();
            }
            return Ok(message);
        }

        // POST: api/messages
        [HttpPost]
        public async Task<ActionResult> CreateMessage(CreateMessageDto createMessageDto)
        {
            await _userMessageService.CreateMessageAsync(createMessageDto);
            return Ok("Message Successfully Created ");
        }

        // PUT: api/messages/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMessage(int id, UpdateMessageDto updateMessageDto)
        {
            if (id != updateMessageDto.MessageId)
            {
                return BadRequest();
            }

            var message = await _userMessageService.GetMessageByIdAsync(id);
            if (message == null)
            {
                return NotFound();
            }

            await _userMessageService.UpdateMessageAsync(updateMessageDto);
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteMessage(int id)
        {
            var message = await _userMessageService.GetMessageByIdAsync(id);
            if (message == null)
            {
                return NotFound();
            }

            await _userMessageService.DeleteMessageAsync(id);
            return NoContent();
        }
    }
}
