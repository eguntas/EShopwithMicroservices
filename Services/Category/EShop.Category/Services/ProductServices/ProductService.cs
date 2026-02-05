using AutoMapper;
using Eshop.Category.Dtos.ProductDtos;
using Eshop.Category.Entities;
using Eshop.Category.Settings;
using EShop.Category.Dtos.ProductDtos;
using MongoDB.Driver;

namespace Eshop.Category.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<Product> _productCollection;
        private readonly IMongoCollection<Category.Entities.Category> _categoryCollection;

        public ProductService(IMapper mapper  , IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _productCollection = database.GetCollection<Product>(_databaseSettings.ProductCollectionName); 
            _categoryCollection = database.GetCollection<Category.Entities.Category>(_databaseSettings.CategoryCollectionName);
            _mapper = mapper;
        }

        public async Task CreateProductAsync(CreateProductDto createProductDto)
        {
            var value = _mapper.Map<Product>(createProductDto);
            await _productCollection.InsertOneAsync(value);
        }

        public async Task DeleteProductAsync(string id)
        {
            await _productCollection.DeleteOneAsync(x=>x.ProductID == id);    
        }

        public async Task<List<ResultProductDto>> GetAllProductAsync()
        {
            var values = await _productCollection.Find(x=>true).ToListAsync();
            return _mapper.Map<List<ResultProductDto>>(values);
        }

        public async Task<GetByIdProductDto> GetByIdProductAsync(string id)
        {
            var value = await _productCollection.Find<Product>(x=>x.ProductID == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductDto>(value);
        }

        public async Task<List<ResultProductWithCategoryDto>> GetProductsWithCategoryAsync()
        {
            var values = await _productCollection.Find(x=>true).ToListAsync();
            foreach(var item in values)
            {
                item.Category = await _categoryCollection.Find<Category.Entities.Category>(x=>x.CategoryID == item.CategoryID).FirstOrDefaultAsync();
            }
            return _mapper.Map<List<ResultProductWithCategoryDto>>(values);
        }

        public async Task<List<ResultProductWithCategoryDto>> GetProductsWithCategoryByCategoryIdAsync(string CategoryId)
        {
            var values = await _productCollection.Find(x => x.CategoryID == CategoryId).ToListAsync();
            foreach (var item in values)
            {
                item.Category = await _categoryCollection.Find<Category.Entities.Category>(x => x.CategoryID == item.CategoryID).FirstOrDefaultAsync();
            }
            return _mapper.Map<List<ResultProductWithCategoryDto>>(values);
        }

        public async Task UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            var value = _mapper.Map<Product>(updateProductDto);
            await _productCollection.FindOneAndReplaceAsync(x=>x.ProductID == updateProductDto.ProductID,value);
        }
    }
}
