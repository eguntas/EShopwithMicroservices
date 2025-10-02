using AutoMapper;
using Eshop.Category.Dtos.CategoryDtos;
using Eshop.Category.Entities;
using Eshop.Category.Settings;
using MongoDB.Driver;

namespace Eshop.Category.Services.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly IMongoCollection<Eshop.Category.Entities.Category> _categoryCollection;
        private readonly IMapper _mapper;
        public CategoryService(IMapper mapper , IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _categoryCollection = database.GetCollection<Eshop.Category.Entities.Category>(_databaseSettings.CategoryCollectionName);
            _mapper = mapper;            
        }
        public async Task CreateCategoryAsync(CreateCategoryDto createCategoryDto)
        {
            var value = _mapper.Map<Eshop.Category.Entities.Category>(createCategoryDto);
            await _categoryCollection.InsertOneAsync(value); 
        }

        public async Task DeleteCategoryAsync(string id)
        {
            await _categoryCollection.DeleteOneAsync(x => x.CategoryID == id);
        }

        public async Task<List<ResultCategoryDto>> GetAllCategoryAsync()
        {
            var values = await _categoryCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultCategoryDto>>(values);
        }

        public async Task<GetByIdCategoryDto> GetByIdCategoryAsync(string id)
        {
            var value = _categoryCollection.Find<Eshop.Category.Entities.Category>(x=>x.CategoryID == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdCategoryDto>(value);
        }

        public async Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
        {
            var value = _mapper.Map<Eshop.Category.Entities.Category>(updateCategoryDto);
            await _categoryCollection.FindOneAndReplaceAsync(x => x.CategoryID == updateCategoryDto.CategoryID , value);
        }
    }
}
