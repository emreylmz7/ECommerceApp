using AutoMapper;
using MongoDB.Driver;
using OllieShop.Catalog.Dtos.ProductStockDtos;
using OllieShop.Catalog.Entities;
using OllieShop.Catalog.Settings;

namespace OllieShop.Catalog.Services.ProductStockServices
{
    public class ProductStockService : IProductStockService
    {
        private readonly IMongoCollection<ProductStock> _productStockCollection;
        private readonly IMongoCollection<Product> _productCollection;
        private readonly IMongoCollection<Size> _sizeCollection;
        private readonly IMongoCollection<Color> _colorCollection;
        private readonly IMapper _mapper;

        public ProductStockService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _productStockCollection = database.GetCollection<ProductStock>(_databaseSettings.ProductStockCollectionName);
            _productCollection = database.GetCollection<Product>(_databaseSettings.ProductCollectionName);
            _sizeCollection = database.GetCollection<Size>(_databaseSettings.SizeCollectionName);
            _colorCollection = database.GetCollection<Color>(_databaseSettings.ColorCollectionName);
            _mapper = mapper;
        }

        public async Task CreateProductStockAsync(CreateProductStockDto createProductStockDto)
        {
            var value = _mapper.Map<ProductStock>(createProductStockDto);
            await _productStockCollection.InsertOneAsync(value);
        }

        public async Task DeleteProductStockAsync(string id)
        {
            await _productStockCollection.DeleteOneAsync(x => x.ProductStockId == id);
        }

        public async Task<List<ResultProductStockDto>> GetAllProductStockAsync()
        {
            var values = await _productStockCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultProductStockDto>>(values);
        }

        public async Task<GetProductStockByIdDto> GetByIdProductStockAsync(string id)
        {
            var productStock = await _productStockCollection.Find<ProductStock>(x => x.ProductStockId == id).FirstOrDefaultAsync();

            var product = await _productCollection.Find<Product>(x => x.ProductId == productStock.ProductId).FirstOrDefaultAsync();
            var size = await _sizeCollection.Find<Size>(x => x.SizeId == productStock.SizeId).FirstOrDefaultAsync();
            var color = await _colorCollection.Find<Color>(x => x.ColorId == productStock.ColorId).FirstOrDefaultAsync();

            var productStockDetails = new GetProductStockByIdDto
            {
                ProductStockId = productStock.ProductStockId,
                ProductId = productStock.ProductId,
                ProductName = product.Name!,
                SizeId = productStock.SizeId,
                Size = size.Name,
                ColorId = productStock.ColorId,
                Color = color.Name,
                Stock = productStock.Stock
            };

            return productStockDetails;
        }

        public async Task<List<GetProductStockByIdDto>> GetProductStocksByProductId(string productId)
        {
            var values = await _productStockCollection.Find<ProductStock>(x => x.ProductId == productId).ToListAsync();
            var mappedValues = _mapper.Map<List<GetProductStockByIdDto>>(values);
            return mappedValues;
        }

        public async Task<List<ResultProductStockWithDetailsDto>> GetProductStocksWithDetails()
        {
            var productStocks = await _productStockCollection.Find(x => true).ToListAsync();

            var productStockDetails = new List<ResultProductStockWithDetailsDto>();

            foreach (var productStock in productStocks)
            {
                var product = await _productCollection.Find<Product>(x => x.ProductId == productStock.ProductId).FirstOrDefaultAsync();
                var size = await _sizeCollection.Find<Size>(x => x.SizeId == productStock.SizeId).FirstOrDefaultAsync();
                var color = await _colorCollection.Find<Color>(x => x.ColorId == productStock.ColorId).FirstOrDefaultAsync();

                var productStockDetail = new ResultProductStockWithDetailsDto
                {
                    ProductStockId = productStock.ProductStockId,
                    ProductId = productStock.ProductId,
                    ProductName = product.Name!,
                    SizeId = productStock.SizeId,
                    Size = size.Name,
                    ColorId = productStock.ColorId,
                    Color = color.Name,
                    Stock = productStock.Stock
                };

                productStockDetails.Add(productStockDetail);
            }

            return productStockDetails;
        }


        public async Task UpdateProductStockAsync(UpdateProductStockDto updateProductStockDto)
        {
            var value = _mapper.Map<ProductStock>(updateProductStockDto);
            await _productStockCollection.FindOneAndReplaceAsync(x => x.ProductStockId == updateProductStockDto.ProductStockId, value);
        }
    }
}
