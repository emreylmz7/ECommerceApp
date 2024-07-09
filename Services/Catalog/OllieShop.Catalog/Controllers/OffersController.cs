using Microsoft.AspNetCore.Mvc;
using OllieShop.Catalog.Dtos.OfferDtos;
using OllieShop.Catalog.Services.OfferServices;

namespace OllieShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OffersController : ControllerBase
    {
        private readonly IOfferService _offerService;

        public OffersController(IOfferService offerService)
        {
            _offerService = offerService;
        }

        [HttpGet]
        public async Task<IActionResult> OfferList()
        {
            var values = await _offerService.GetAllOfferAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOfferById(string id)
        {
            var value = await _offerService.GetByIdOfferAsync(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOffer(CreateOfferDto createOfferDto)
        {
            await _offerService.CreateOfferAsync(createOfferDto);
            return Ok("Offer Added Successfully.");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteOffer(string id)
        {
            await _offerService.DeleteOfferAsync(id);
            return Ok("Offer Deleted Successfully.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOffer(UpdateOfferDto updateOfferDto)
        {
            await _offerService.UpdateOfferAsync(updateOfferDto);
            return Ok("Offer Updated Successfully.");
        }
    }
}
