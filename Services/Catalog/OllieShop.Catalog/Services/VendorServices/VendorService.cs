using AutoMapper;
using MongoDB.Driver;
using OllieShop.Catalog.Dtos.VendorDtos;
using OllieShop.Catalog.Entities;
using OllieShop.Catalog.Settings;

namespace OllieShop.Catalog.Services.VendorServices
{
    public class VendorService : IVendorService
    {
        private readonly IMongoCollection<Vendor> _vendorCollection;
        private readonly IMapper _mapper;

        public VendorService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _vendorCollection = database.GetCollection<Vendor>(_databaseSettings.VendorCollectionName);
            _mapper = mapper;
        }

        public async Task CreateVendorAsync(CreateVendorDto createVendorDto)
        {
            var value = _mapper.Map<Vendor>(createVendorDto);
            await _vendorCollection.InsertOneAsync(value);
        }

        public async Task DeleteVendorAsync(string id)
        {
            await _vendorCollection.DeleteOneAsync(x => x.VendorId == id);
        }

        public async Task<List<ResultVendorDto>> GetAllVendorAsync()
        {
            var values = await _vendorCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultVendorDto>>(values);
        }

        public async Task<GetVendorByIdDto> GetByIdVendorAsync(string id)
        {
            var values = await _vendorCollection.Find<Vendor>(x => x.VendorId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetVendorByIdDto>(values);
        }

        public async Task UpdateVendorAsync(UpdateVendorDto updateVendorDto)
        {
            var values = _mapper.Map<Vendor>(updateVendorDto);
            await _vendorCollection.FindOneAndReplaceAsync(x => x.VendorId == updateVendorDto.VendorId, values);
        }
    }
}
