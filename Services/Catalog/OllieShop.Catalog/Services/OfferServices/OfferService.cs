using AutoMapper;
using MongoDB.Driver;
using OllieShop.Catalog.Dtos.OfferDtos;
using OllieShop.Catalog.Entities;
using OllieShop.Catalog.Settings;

namespace OllieShop.Catalog.Services.OfferServices
{
    public class OfferService : IOfferService
    {
        private readonly IMongoCollection<Offer> _offerCollection;
        private readonly IMapper _mapper;

        public OfferService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _offerCollection = database.GetCollection<Offer>(_databaseSettings.OfferCollectionName);
            _mapper = mapper;
        }

        public async Task CreateOfferAsync(CreateOfferDto createOfferDto)
        {
            var value = _mapper.Map<Offer>(createOfferDto);
            await _offerCollection.InsertOneAsync(value);
        }

        public async Task DeleteOfferAsync(string id)
        {
            await _offerCollection.DeleteOneAsync(x => x.OfferId == id);
        }

        public async Task<List<ResultOfferDto>> GetAllOfferAsync()
        {
            var values = await _offerCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultOfferDto>>(values);
        }

        public async Task<GetOfferByIdDto> GetByIdOfferAsync(string id)
        {
            var values = await _offerCollection.Find<Offer>(x => x.OfferId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetOfferByIdDto>(values);
        }

        public async Task UpdateOfferAsync(UpdateOfferDto updateOfferDto)
        {
            var values = _mapper.Map<Offer>(updateOfferDto);
            await _offerCollection.FindOneAndReplaceAsync(x => x.OfferId == updateOfferDto.OfferId, values);
        }
    }
}
