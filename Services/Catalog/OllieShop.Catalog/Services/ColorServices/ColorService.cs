using AutoMapper;
using MongoDB.Driver;
using OllieShop.Catalog.Dtos.ColorDtos;
using OllieShop.Catalog.Entities;
using OllieShop.Catalog.Settings;

namespace OllieShop.Catalog.Services.ColorServices
{
    public class ColorService : IColorService
    {
        private readonly IMongoCollection<Color> _colorCollection;
        private readonly IMapper _mapper;

        public ColorService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _colorCollection = database.GetCollection<Color>(_databaseSettings.ColorCollectionName);
            _mapper = mapper;
        }

        public async Task CreateColorAsync(CreateColorDto createColorDto)
        {
            var value = _mapper.Map<Color>(createColorDto);
            await _colorCollection.InsertOneAsync(value);
        }

        public async Task DeleteColorAsync(string id)
        {
            await _colorCollection.DeleteOneAsync(x => x.ColorId == id);
        }

        public async Task<List<ResultColorDto>> GetAllColorAsync()
        {
            var values = await _colorCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultColorDto>>(values);
        }

        public async Task<GetColorByIdDto> GetByIdColorAsync(string id)
        {
            var value = await _colorCollection.Find<Color>(x => x.ColorId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetColorByIdDto>(value);
        }

        public async Task UpdateColorAsync(UpdateColorDto updateColorDto)
        {
            var value = _mapper.Map<Color>(updateColorDto);
            await _colorCollection.FindOneAndReplaceAsync(x => x.ColorId == updateColorDto.ColorId, value);
        }
    }
}
