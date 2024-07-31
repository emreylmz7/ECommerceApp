using Microsoft.AspNetCore.Mvc;
using OllieShop.DtoLayer.CatalogDtos.Contact;
using OllieShop.WebUI.Services.CatalogServices.AboutServices;
using OllieShop.WebUI.Services.CatalogServices.ContactServices;

namespace OllieShop.WebUI.Controllers
{
    public class ContactController : Controller
    {
        private readonly IAboutService _aboutService;
        private readonly IContactService _contactService;
        public ContactController(IAboutService aboutService, IContactService contactService)
        {
            _aboutService = aboutService;
            _contactService = contactService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var abouts = (await _aboutService.GetAllAboutAsync()).Take(1).ToList();
            return View(abouts);
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateContactDto createContactDto)
        {
            createContactDto.SendDate = DateTime.Now;
            createContactDto.IsRead = true;

            var responseMessage = await _contactService.CreateContactAsync(createContactDto);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Default");
            }
            return View();
        }
    }
}
