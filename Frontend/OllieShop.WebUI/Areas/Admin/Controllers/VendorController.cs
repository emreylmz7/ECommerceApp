using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OllieShop.DtoLayer.CatalogDtos.Vendor;
using OllieShop.WebUI.Services.ApiServices;

namespace OllieShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    [Route("Admin/Vendor")]
    public class VendorController : Controller
    {
        private readonly IApiService _apiService;

        public VendorController(IApiService apiService)
        {
            _apiService = apiService;
        }

        [Route("Index")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var vendors = await _apiService.GetAsync<List<ResultVendorDto>>("https://localhost:7220/api/Vendors");
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
            var responseMessage = await _apiService.PostAsync("https://localhost:7220/api/Vendors", createVendorDto);
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
            var responseMessage = await _apiService.DeleteAsync($"https://localhost:7220/api/Vendors?id={id}");
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
            var vendor = await _apiService.GetAsync<UpdateVendorDto>($"https://localhost:7220/api/Vendors/{id}");
            return View(vendor);
        }

        [HttpPost]
        [Route("UpdateVendor/{id}")]
        public async Task<IActionResult> UpdateVendor(UpdateVendorDto updateVendorDto)
        {
            var responseMessage = await _apiService.PutAsync("https://localhost:7220/api/Vendors", updateVendorDto);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Vendor", new { area = "Admin" });
            }
            return View();
        }
    }
}
