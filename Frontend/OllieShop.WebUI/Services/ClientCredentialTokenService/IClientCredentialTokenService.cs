namespace OllieShop.WebUI.Services.ClientCredentialTokenService
{
    public interface IClientCredentialTokenService
    {
        Task<string> GetToken();
    }
}
