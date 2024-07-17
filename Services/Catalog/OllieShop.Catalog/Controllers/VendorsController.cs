using Microsoft.AspNetCore.Mvc;
using OllieShop.Catalog.Dtos.VendorDtos;
using OllieShop.Catalog.Services.VendorServices;

namespace OllieShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendorsController : ControllerBase
    {
        private readonly IVendorService _vendorService;

        public VendorsController(IVendorService vendorService)
        {
            _vendorService = vendorService;
        }

        [HttpGet]
        public async Task<IActionResult> VendorList()
        {
            var values = await _vendorService.GetAllVendorAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVendorById(string id)
        {
            var value = await _vendorService.GetByIdVendorAsync(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateVendor(CreateVendorDto createVendorDto)
        {
            await _vendorService.CreateVendorAsync(createVendorDto);
            return Ok("Vendor Added Successfully.");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteVendor(string id)
        {
            await _vendorService.DeleteVendorAsync(id);
            return Ok("Vendor Deleted Successfully.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateVendor(UpdateVendorDto updateVendorDto)
        {
            await _vendorService.UpdateVendorAsync(updateVendorDto);
            return Ok("Vendor Updated Successfully.");
        }
    }
}
