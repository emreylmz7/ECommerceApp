namespace OllieShop.WebUI.Services.ImagesServices
{
    public interface IImagesService
    {
        Task<string> UploadImageAsync(IFormFile file);
        Task<bool> DeleteImageAsync(string fileName);
        Task<string> GetSignedUrlAsync(string fileName);
    }
}
