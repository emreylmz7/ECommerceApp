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
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMongoCollection<ProductImage> _productImageCollection;
        private readonly IMongoCollection<ProductDetail> _productDetailCollection;
        private readonly IMapper _mapper;

        public ProductService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _productCollection = database.GetCollection<Product>(databaseSettings.ProductCollectionName); 
            _categoryCollection = database.GetCollection<Category>(databaseSettings.CategoryCollectionName);
            _productImageCollection = database.GetCollection<ProductImage>(databaseSettings.ProductImageCollectionName);
            _productDetailCollection = database.GetCollection<ProductDetail>(databaseSettings.ProductDetailCollectionName); 
            _mapper = mapper;
        }

        public async Task CreateProductAsync(CreateProductDto createProductDto) 
        {
            var value = _mapper.Map<Product>(createProductDto);
            await _productCollection.InsertOneAsync(value);
            var productImages = new ProductImage
            {
                Images = new List<string>
                {
                    "noproduct1.png",
                    "noproduct1.png",
                    "noproduct1.png",
                    "noproduct1.png"
                },
                ProductId = value.ProductId
            };
            var productDetail = new ProductDetail
            { 
                ProductId = value.ProductId,
                Description = "Ollie Shop Default Product Description",
                Information = "Ollie Shop Default Product Information"
            };
            await _productImageCollection.InsertOneAsync(productImages);
            await _productDetailCollection.InsertOneAsync(productDetail);
        }

        public async Task DeleteProductAsync(string id)
        {
            await _productCollection.DeleteOneAsync(x => x.ProductId == id); 
            await _productImageCollection.DeleteOneAsync(x => x.ProductId == id); 
            await _productDetailCollection.DeleteOneAsync(x => x.ProductId == id); 
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

        public async Task<List<ResultProductsWithCategoryDto>> GetProductsByCategoryIdAsync(string categoryId)
        {
            var values = await _productCollection.Find<Product>(x => x.CategoryId == categoryId).ToListAsync();
            var mappedValues = _mapper.Map<List<ResultProductsWithCategoryDto>>(values);

            foreach (var item in mappedValues)
            {
                item.CategoryName = (await _categoryCollection.Find<Category>(x => x.CategoryId == categoryId).FirstAsync()).Name;
            }
            return mappedValues;

        }

        public async Task<List<ResultProductsWithCategoryDto>> GetProductsWithCategoryAsync()
        {
            var products = await _productCollection.Find<Product>(x => true).ToListAsync();

            var categoryIds = products.Select(p => p.CategoryId).Distinct();
            var categories = await _categoryCollection.Find<Category>(c => categoryIds.Contains(c.CategoryId)).ToListAsync();
            var categoryDict = categories.ToDictionary(c => c.CategoryId, c => c.Name);

            var mappedProducts = products.Select(item =>
            {
                var mappedItem = _mapper.Map<ResultProductsWithCategoryDto>(item);
                mappedItem.CategoryName = categoryDict[item.CategoryId];
                return mappedItem;
            }).ToList();

            return mappedProducts;
        }

        public async Task UpdateProductAsync(UpdateProductDto updateProductDto) 
        {
            var value = _mapper.Map<Product>(updateProductDto);
            await _productCollection.FindOneAndReplaceAsync(x => x.ProductId == updateProductDto.ProductId, value); 
        }
    }
}
