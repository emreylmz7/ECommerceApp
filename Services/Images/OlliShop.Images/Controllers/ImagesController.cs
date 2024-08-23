using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OlliShop.Images.Services;

namespace OlliShop.Images.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly ICloudStorageService _cloudStorageService;

        public ImagesController(ICloudStorageService cloudStorageService)
        {
            _cloudStorageService = cloudStorageService;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadImage(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("No file uploaded.");

            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            string url = await _cloudStorageService.UploadFileAsync(file, fileName);

            return Ok(new { Url = url });
        }

        [HttpDelete("delete/{fileName}")]
        public async Task<IActionResult> DeleteImage(string fileName)
        {
            await _cloudStorageService.DeleteFileAsync(fileName);
            return Ok(new { Message = "File deleted successfully." });
        }

        [HttpGet("signed-url/{fileName}")]
        public async Task<IActionResult> GetSignedUrl(string fileName)
        {
            string signedUrl = await _cloudStorageService.GetSignedUrlAsync(fileName);
            return Ok(new { SignedUrl = signedUrl });
        }
    }
}
