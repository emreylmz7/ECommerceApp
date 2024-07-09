using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OllieShop.DtoLayer.CatalogDtos.Offer;
using OllieShop.WebUI.Services.ApiServices;

namespace OllieShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    [Route("Admin/Offer")]
    public class OfferController : Controller
    {
        private readonly IApiService _apiService;

        public OfferController(IApiService apiService)
        {
            _apiService = apiService;
        }

        [Route("Index")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var offers = await _apiService.GetAsync<List<ResultOfferDto>>("https://localhost:7220/api/Offers");
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
            var responseMessage = await _apiService.PostAsync("https://localhost:7220/api/Offers", createOfferDto);
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
            var responseMessage = await _apiService.DeleteAsync($"https://localhost:7220/api/Offers?id={id}");
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
            var offer = await _apiService.GetAsync<UpdateOfferDto>($"https://localhost:7220/api/Offers/{id}");
            return View(offer);
        }

        [HttpPost]
        [Route("UpdateOffer/{id}")]
        public async Task<IActionResult> UpdateOffer(UpdateOfferDto updateOfferDto)
        {
            var responseMessage = await _apiService.PutAsync("https://localhost:7220/api/Offers", updateOfferDto);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Offer", new { area = "Admin" });
            }
            return View();
        }
    }
}
