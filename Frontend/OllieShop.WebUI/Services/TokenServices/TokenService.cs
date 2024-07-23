using Newtonsoft.Json.Linq;

namespace OllieShop.WebUI.Services.TokenServices
{
    public class TokenService : ITokenService
    {
        public async Task<string> GetTokenAsync()
        {
            string token = "";
            using (var httpClient = new HttpClient())
            {
                var request = new HttpRequestMessage
                {
                    RequestUri = new Uri("http://localhost:5001/connect/token"),
                    Method = HttpMethod.Post,
                    Content = new FormUrlEncodedContent(new Dictionary<string, string>
                {
                    {"client_id","OllieShopVisitorId" },
                    {"client_secret","ollieshopsecret" },
                    {"grant_type","client_credentials" }
                })
                };

                using (var response = await httpClient.SendAsync(request))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        var tokenResponse = JObject.Parse(content);
                        token = tokenResponse["access_token"]!.ToString();
                    }
                }
            }
            return token;
        }
    }
}
