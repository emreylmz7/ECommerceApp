using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OllieShop.Catalog.Dtos.SizeDtos;
using OllieShop.Catalog.Services.SizeServices;

namespace OllieShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SizesController : ControllerBase
    {
        private readonly ISizeService _sizeService;

        public SizesController(ISizeService sizeService)
        {
            _sizeService = sizeService;
        }

        [HttpGet]
        public async Task<IActionResult> SizeList()
        {
            var values = await _sizeService.GetAllSizeAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSizeById(string id)
        {
            var value = await _sizeService.GetByIdSizeAsync(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSize(CreateSizeDto createSizeDto)
        {
            await _sizeService.CreateSizeAsync(createSizeDto);
            return Ok("Size Added Successfully.");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteSize(string id)
        {
            await _sizeService.DeleteSizeAsync(id);
            return Ok("Size Deleted Successfully.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSize(UpdateSizeDto updateSizeDto)
        {
            await _sizeService.UpdateSizeAsync(updateSizeDto);
            return Ok("Size Updated Successfully.");
        }
    }
}
