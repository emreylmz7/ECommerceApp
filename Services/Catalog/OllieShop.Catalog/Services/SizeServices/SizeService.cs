using AutoMapper;
using MongoDB.Driver;
using OllieShop.Catalog.Dtos.SizeDtos;
using OllieShop.Catalog.Entities;
using OllieShop.Catalog.Settings;

namespace OllieShop.Catalog.Services.SizeServices
{
    public class SizeService : ISizeService
    {
        private readonly IMongoCollection<Size> _sizeCollection;
        private readonly IMapper _mapper;

        public SizeService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _sizeCollection = database.GetCollection<Size>(_databaseSettings.SizeCollectionName);
            _mapper = mapper;
        }

        public async Task CreateSizeAsync(CreateSizeDto createSizeDto)
        {
            var value = _mapper.Map<Size>(createSizeDto);
            await _sizeCollection.InsertOneAsync(value);
        }

        public async Task DeleteSizeAsync(string id)
        {
            await _sizeCollection.DeleteOneAsync(x => x.SizeId == id);
        }

        public async Task<List<ResultSizeDto>> GetAllSizeAsync()
        {
            var values = await _sizeCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultSizeDto>>(values);
        }

        public async Task<GetSizeByIdDto> GetByIdSizeAsync(string id)
        {
            var value = await _sizeCollection.Find<Size>(x => x.SizeId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetSizeByIdDto>(value);
        }

        public async Task UpdateSizeAsync(UpdateSizeDto updateSizeDto)
        {
            var value = _mapper.Map<Size>(updateSizeDto);
            await _sizeCollection.FindOneAndReplaceAsync(x => x.SizeId == updateSizeDto.SizeId, value);
        }
    }
}
