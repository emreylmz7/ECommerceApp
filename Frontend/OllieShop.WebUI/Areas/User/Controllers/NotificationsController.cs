using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OllieShop.DtoLayer.MessageDtos;
using OllieShop.WebUI.Services.IUserService;
using OllieShop.WebUI.Services.MessageServices;

namespace OllieShop.WebUI.Areas.User.Controllers
{
    [Authorize]
    [Area("User")]
    [Route("User/Notifications")]
    public class NotificationsController : Controller
    {
        private readonly IMessageService _messageService;
        private readonly IUserService _userService;
        public NotificationsController(IMessageService messageService, IUserService userService)
        {
            _messageService = messageService;
            _userService = userService;
        }

        [Route("Index")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var messages = await _messageService.GetAllMessagesAsync();
            return View(messages);
        }

        [Route("Inbox")]
        [HttpGet]
        public async Task<IActionResult> Inbox()
        {
            var messages = await _messageService.GetInboxMessagesAsync();
            return View(messages);
        }

        [Route("Sendbox")]
        [HttpGet]
        public async Task<IActionResult> Sendbox()
        {
            var messages = await _messageService.GetSendboxMessagesAsync();
            return View(messages);
        }

        [Route("MessageDetails")]
        [HttpGet]
        public async Task<IActionResult> MessageDetails(int id)
        {
            var message = await _messageService.GetMessageByIdAsync(id);   
            return View(message);
        }

        [Route("SendMessage")]
        [HttpGet]
        public IActionResult SendMessage()
        {
            return View();
        }

        [Route("SendMessage")]
        [HttpPost]
        public async Task<IActionResult> SendMessage(CreateMessageDto createMessageDto)
        {
            var user = await _userService.GetUserInfoAsync(); 
            if (user != null)
            {
                createMessageDto.SenderName = user.Name + " " + user.Surname;
                createMessageDto.SenderId = user.Id;
                createMessageDto.ReceiverId = "97973c28-5a2a-4327-bbda-47318df84214";
                createMessageDto.ReceiverName = "Admin";
                createMessageDto.SentAt = DateTime.Now;
                createMessageDto.IsRead = false;

                await _messageService.CreateMessageAsync(createMessageDto);
            }
            return View();
        }
    }
}
