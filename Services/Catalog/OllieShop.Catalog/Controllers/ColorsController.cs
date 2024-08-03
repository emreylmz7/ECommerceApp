using Microsoft.AspNetCore.Mvc;
using OllieShop.Catalog.Dtos.ColorDtos;
using OllieShop.Catalog.Services.ColorServices;

namespace OllieShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorsController : ControllerBase
    {
        private readonly IColorService _colorService;

        public ColorsController(IColorService colorService)
        {
            _colorService = colorService;
        }

        [HttpGet]
        public async Task<IActionResult> ColorList()
        {
            var values = await _colorService.GetAllColorAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetColorById(string id)
        {
            var value = await _colorService.GetByIdColorAsync(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateColor(CreateColorDto createColorDto)
        {
            await _colorService.CreateColorAsync(createColorDto);
            return Ok("Color Added Successfully.");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteColor(string id)
        {
            await _colorService.DeleteColorAsync(id);
            return Ok("Color Deleted Successfully.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateColor(UpdateColorDto updateColorDto)
        {
            await _colorService.UpdateColorAsync(updateColorDto);
            return Ok("Color Updated Successfully.");
        }
    }
}
