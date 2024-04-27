using AutoMapper;
using MongoDB.Driver;
using OllieShop.Catalog.Dtos.ProductDtos; 
using OllieShop.Catalog.Entities;
using OllieShop.Catalog.Services.ProductServices;
using OllieShop.Catalog.Settings;

namespace OllieShop.Catalog.Services.ProductService
{
    public class ProductService : IProductService 
    {
        private readonly IMongoCollection<Product> _productCollection;
        private readonly IMapper _mapper;

        public ProductService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _productCollection = database.GetCollection<Product>(databaseSettings.ProductCollectionName); 
            _mapper = mapper;
        }

        public async Task CreateProductAsync(CreateProductDto createProductDto) 
        {
            var value = _mapper.Map<Product>(createProductDto);
            await _productCollection.InsertOneAsync(value);
        }

        public async Task DeleteProductAsync(string id)
        {
            await _productCollection.DeleteOneAsync(x => x.ProductId == id); 
        }

        public async Task<List<ResultProductDto>> GetAllProductAsync() 
        {
            var values = await _productCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultProductDto>>(values);
        }

        public async Task<GetByIdProductDto> GetByIdProductAsync(string id) 
        {
            var values = await _productCollection.Find<Product>(x => x.ProductId == id).FirstOrDefaultAsync(); 
            return _mapper.Map<GetByIdProductDto>(values);
        }

        public async Task UpdateProductAsync(UpdateProductDto updateProductDto) 
        {
            var value = _mapper.Map<Product>(updateProductDto);
            await _productCollection.FindOneAndReplaceAsync(x => x.ProductId == updateProductDto.ProductId, value); 
        }
    }
}
