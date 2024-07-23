namespace OllieShop.WebUI.Settings
{
    public class ClientSettings
    {
        public Client OllieShopVisitorClient { get; set; }
        public Client OllieShopManagerClient { get; set; }
        public Client OllieShopAdminClient { get; set; }
    }

    public class Client
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
    }
}
