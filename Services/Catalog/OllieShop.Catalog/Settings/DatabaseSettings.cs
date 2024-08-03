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
        public string CarouselCollectionName { get ; set ; } = null!;
        public string OfferCollectionName { get ; set ; } = null!;
        public string FeatureCollectionName { get; set ; } = null!;
        public string VendorCollectionName { get ; set ; } = null!;
        public string AboutCollectionName { get ; set ; } = null!;
        public string ContactCollectionName { get ; set ; } = null!;
        public string SizeCollectionName { get ; set ; } = null!;
        public string ColorCollectionName { get ; set ; } = null!;
        public string ProductStockCollectionName { get ; set ; } = null!;
    }
}
