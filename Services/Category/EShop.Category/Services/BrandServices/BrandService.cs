using AutoMapper;
using Eshop.Category.Dtos.CategoryDtos;
using Eshop.Category.Settings;
using EShop.Brand.Services.BrandServices;
using EShop.Category.Dtos.BrandDtos;
using EShop.Category.Entities;
using MongoDB.Driver;

namespace EShop.Category.Services.BrandServices
{
    public class BrandService : IBrandService
    {
        private readonly IMongoCollection<EShop.Category.Entities.Brand> _brandCollection;
        private readonly IMapper _mapper;

        public BrandService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _brandCollection = database.GetCollection<EShop.Category.Entities.Brand>(_databaseSettings.BrandCollectionName);
            _mapper = mapper;
        }
        public async Task CreateBrandAsync(CreateBrandDto createBrandDto)
        {
            var value = _mapper.Map<EShop.Category.Entities.Brand>(createBrandDto);
            await _brandCollection.InsertOneAsync(value);
        }

        public async Task DeleteBrandAsync(string id)
        {
            await _brandCollection.DeleteOneAsync(x => x.BrandID == id);
        }

        public async Task<List<ResultBrandDto>> GetAllBrandAsync()
        {
            var values = await _brandCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultBrandDto>>(values);
        }

        public async Task<GetByIdBrandDto> GetByIdBrandAsync(string id)
        {
            var value = await _brandCollection.Find<EShop.Category.Entities.Brand>(x => x.BrandID == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdBrandDto>(value);
        }

        public async Task UpdateBrandAsync(UpdateBrandDto updateBrandDto)
        {
            var value = _mapper.Map<EShop.Category.Entities.Brand>(updateBrandDto);
            await _brandCollection.FindOneAndReplaceAsync(x => x.BrandID == updateBrandDto.BrandID, value);
        }
    }
}
