using Newtonsoft.Json;
using OllieShop.DtoLayer.ImagesDtos;
using System.Net.Http.Headers;

namespace OllieShop.WebUI.Services.ImagesServices
{
    public class ImagesService : IImagesService
    {
        private readonly HttpClient _httpClient;

        public ImagesService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> UploadImageAsync(IFormFile file)
        {
            if (file == null || file.Length == 0)
                throw new ArgumentException("No file provided.");

            using (var content = new MultipartFormDataContent())
            {
                var streamContent = new StreamContent(file.OpenReadStream());
                streamContent.Headers.ContentType = new MediaTypeHeaderValue(file.ContentType);
                content.Add(streamContent, "file", file.FileName);

                var response = await _httpClient.PostAsync("Images/upload", content);
                response.EnsureSuccessStatusCode();

                var responseString = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<UploadResponseDto>(responseString);

                return result!.Url;
            }
        }

        public async Task<bool> DeleteImageAsync(string fileName)
        {
            var response = await _httpClient.DeleteAsync($"Images/delete/{fileName}");
            return response.IsSuccessStatusCode;
        }

        public async Task<string> GetSignedUrlAsync(string fileName)
        {
            var response = await _httpClient.GetAsync($"ImageUpload/signed-url/{fileName}");
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<dynamic>(responseString);

            return result.SignedUrl;
        }
    }
}
