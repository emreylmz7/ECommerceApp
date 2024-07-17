using AutoMapper;
using MongoDB.Driver;
using OllieShop.Catalog.Dtos.ProductImageDtos; 
using OllieShop.Catalog.Entities;
using OllieShop.Catalog.Services.ProductImageServices;
using OllieShop.Catalog.Settings;

namespace OllieShop.Catalog.Services.ProductImageService 
{
    public class ProductImageService : IProductImageService
    {
        private readonly IMongoCollection<ProductImage> _productImageCollection;
        private readonly IMapper _mapper;

        public ProductImageService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _productImageCollection = database.GetCollection<ProductImage>(databaseSettings.ProductImageCollectionName); 
            _mapper = mapper;
        }

        public async Task CreateProductImageAsync(CreateProductImageDto createProductImageDto) 
        {
            var value = _mapper.Map<ProductImage>(createProductImageDto);
            await _productImageCollection.InsertOneAsync(value);
        }

        public async Task DeleteProductImageAsync(string id)
        {
            await _productImageCollection.DeleteOneAsync(x => x.ProductImagesId == id); 
        }

        public async Task<List<ResultProductImageDto>> GetAllProductImageAsync() 
        {
            var values = await _productImageCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultProductImageDto>>(values);
        }

        public async Task<GetByIdProductImageDto> GetByIdProductImageAsync(string id) 
        {
            var values = await _productImageCollection.Find<ProductImage>(x => x.ProductImagesId == id).FirstOrDefaultAsync(); 
            return _mapper.Map<GetByIdProductImageDto>(values);
        }

        public async Task<GetByIdProductImageDto> GetImagesByProductIdAsync(string productId)
        {
            var value = await _productImageCollection.Find<ProductImage>(x => x.ProductId == productId).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductImageDto>(value);
        }

        public async Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto) 
        {
            var value = _mapper.Map<ProductImage>(updateProductImageDto);
            await _productImageCollection.FindOneAndReplaceAsync(x => x.ProductImagesId == updateProductImageDto.ProductImagesId, value); 
        }
    }
}
