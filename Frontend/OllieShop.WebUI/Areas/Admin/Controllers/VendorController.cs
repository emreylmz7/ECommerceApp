using Microsoft.AspNetCore.Mvc;
using OllieShop.DtoLayer.CatalogDtos.Vendor;
using OllieShop.WebUI.Services.CatalogServices.VendorServices;

namespace OllieShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Vendor")]
    public class VendorController : Controller
    {
        private readonly IVendorService _vendorService;

        public VendorController(IVendorService vendorService)
        {
            _vendorService = vendorService;
        }

        [Route("Index")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var vendors = await _vendorService.GetAllVendorAsync();
            return View(vendors);
        }

        [Route("CreateVendor")]
        [HttpGet]
        public IActionResult CreateVendor()
        {
            return View();
        }

        [HttpPost]
        [Route("CreateVendor")]
        public async Task<IActionResult> CreateVendor(CreateVendorDto createVendorDto)
        {
            var responseMessage = await _vendorService.CreateVendorAsync(createVendorDto);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Vendor", new { area = "Admin" });
            }
            return View();
        }

        [Route("DeleteVendor/{id}")]
        [HttpGet]
        public async Task<IActionResult> DeleteVendor(string id)
        {
            var responseMessage = await _vendorService.DeleteVendorAsync(id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Vendor", new { area = "Admin" });
            }
            return View();
        }

        [Route("UpdateVendor/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateVendor(string id)
        {
            var vendor = await _vendorService.GetByIdVendorAsync(id);
            var vendorDto = new UpdateVendorDto
            {
                VendorId = vendor.VendorId,
                ImageUrl = vendor.ImageUrl,
                Name = vendor.Name,
            };
            return View(vendorDto);
        }

        [HttpPost]
        [Route("UpdateVendor/{id}")]
        public async Task<IActionResult> UpdateVendor(UpdateVendorDto updateVendorDto)
        {
            var responseMessage = await _vendorService.UpdateVendorAsync(updateVendorDto);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Vendor", new { area = "Admin" });
            }
            return View();
        }
    }
}
