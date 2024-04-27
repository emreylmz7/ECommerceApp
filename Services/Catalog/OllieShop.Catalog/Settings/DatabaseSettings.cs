namespace OllieShop.Catalog.Settings
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string CategoryCollectionName { get; set; } = null!;
        public string ProductCollectionName { get; set; } = null!;
        public string ProductImageCollectionName { get; set; } = null!;
        public string ProductDetailCollectionName { get; set; } = null!;
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
    }
}
