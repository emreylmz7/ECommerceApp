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

        [HttpGet]
        public async Task<ActionResult> GetAllMessages()
        {
            var messages = await _userMessageService.GetAllMessagesAsync();
            return Ok(messages);
        }

        [HttpGet("inbox")]
        public async Task<ActionResult> GetInboxMessages()
        {
            var inboxMessages = await _userMessageService.GetInboxMessagesAsync();
            return Ok(inboxMessages);
        }

        [HttpGet("sendbox")]
        public async Task<ActionResult> GetSendboxMessages()
        {
            var sendboxMessages = await _userMessageService.GetSendboxMessagesAsync();
            return Ok(sendboxMessages);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetMessageById(int id)
        {
            var message = await _userMessageService.GetMessageByIdAsync(id);
            if (message == null)
            {
                return NotFound();
            }
            return Ok(message);
        }

        [HttpPost]
        public async Task<ActionResult> CreateMessage(CreateMessageDto createMessageDto)
        {
            await _userMessageService.CreateMessageAsync(createMessageDto);
            return Ok("Message Successfully Created ");
        }

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
