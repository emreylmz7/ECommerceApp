namespace OllieShop.WebUI.Services.TokenServices
{
    public interface ITokenService
    {
        Task<string> GetTokenAsync();
    }
}
