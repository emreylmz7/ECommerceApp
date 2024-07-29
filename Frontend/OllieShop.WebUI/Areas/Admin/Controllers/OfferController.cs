using Microsoft.AspNetCore.Mvc;
using OllieShop.DtoLayer.CatalogDtos.Offer;
using OllieShop.WebUI.Services.CatalogServices.OfferServices;

namespace OllieShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Offer")]
    public class OfferController : Controller
    {
        private readonly IOfferService _offerService;

        public OfferController(IOfferService offerService)
        {
            _offerService = offerService;
        }

        [Route("Index")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var offers = await _offerService.GetAllOfferAsync();
            return View(offers);
        }

        [Route("CreateOffer")]
        [HttpGet]
        public IActionResult CreateOffer()
        {
            return View();
        }

        [HttpPost]
        [Route("CreateOffer")]
        public async Task<IActionResult> CreateOffer(CreateOfferDto createOfferDto)
        {
            var responseMessage = await _offerService.CreateOfferAsync(createOfferDto);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Offer", new { area = "Admin" });
            }
            return View();
        }

        [Route("DeleteOffer/{id}")]
        [HttpGet]
        public async Task<IActionResult> DeleteOffer(string id)
        {
            var responseMessage = await _offerService.DeleteOfferAsync(id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Offer", new { area = "Admin" });
            }
            return View();
        }

        [Route("UpdateOffer/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateOffer(string id)
        {
            var offer = await _offerService.GetByIdOfferAsync(id);
            var offer2 = new UpdateOfferDto
            {
                OfferId = offer.OfferId,
                StartDate = offer.StartDate,
                SubTitle = offer.SubTitle,
                Description = offer.Description,
                DiscountPercentage = offer.DiscountPercentage,
                EndDate = offer.EndDate,
                ImageUrl = offer.ImageUrl,
                Title = offer.Title,
            };
            return View(offer2);
        }

        [HttpPost]
        [Route("UpdateOffer/{id}")]
        public async Task<IActionResult> UpdateOffer(UpdateOfferDto updateOfferDto)
        {
            var responseMessage = await _offerService.UpdateOfferAsync(updateOfferDto);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Offer", new { area = "Admin" });
            }
            return View();
        }
    }
}
