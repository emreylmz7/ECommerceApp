using AutoMapper;
using MongoDB.Driver;
using OllieShop.Catalog.Dtos.CarouselDtos;
using OllieShop.Catalog.Dtos.CategoryDtos;
using OllieShop.Catalog.Entities;
using OllieShop.Catalog.Settings;

namespace OllieShop.Catalog.Services.CarouselServices
{
    public class CarouselService : ICarouselService
    {
        private readonly IMongoCollection<Carousel> _carouselCollection;
        private readonly IMapper _mapper;

        public CarouselService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _carouselCollection = database.GetCollection<Carousel>(_databaseSettings.CarouselCollectionName);
            _mapper = mapper;
        }
        public async Task CreateCarouselAsync(CreateCarouselDto createCarouselDto)
        {
            var value = _mapper.Map<Carousel>(createCarouselDto);
            await _carouselCollection.InsertOneAsync(value);
        }

        public async Task DeleteCarouselAsync(string id)
        {
            await _carouselCollection.DeleteOneAsync(x => x.CarouselId == id);
        }

        public async Task<List<ResultCarouselDto>> GetAllCarouselAsync()
        {
            var values = await _carouselCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultCarouselDto>>(values);
        }

        public async Task<GetCarouselByIdDto> GetByIdCarouselAsync(string id)
        {
            var values = await _carouselCollection.Find<Carousel>(x => x.CarouselId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetCarouselByIdDto>(values);
        }

        public async Task UpdateCarouselAsync(UpdateCarouselDto updateCarouselDto)
        {
            var values = _mapper.Map<Carousel>(updateCarouselDto);
            await _carouselCollection.FindOneAndReplaceAsync(x => x.CarouselId == updateCarouselDto.CarouselId, values);
        }
    }
}
