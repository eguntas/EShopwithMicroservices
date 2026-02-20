using Eshop.Category.Entities;
using Eshop.Category.Settings;
using EShop.Category.Entities;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;

namespace EShop.Category.Services.StatisticServices
{

    public class StatisticService : IStatisticService
    {
        private readonly IMongoCollection<Product> _productCollection;
        private readonly IMongoCollection<Eshop.Category.Entities.Category> _categoryCollection;
        private readonly IMongoCollection<EShop.Category.Entities.Brand> _brandCollection;

        public StatisticService(IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _productCollection = database.GetCollection<Product>(_databaseSettings.ProductCollectionName);
            _categoryCollection = database.GetCollection<Eshop.Category.Entities.Category>(_databaseSettings.CategoryCollectionName);
            _brandCollection = database.GetCollection<EShop.Category.Entities.Brand>(_databaseSettings.BrandCollectionName);         
        }
        
        public async Task<long> GetBrandCount()
        {
            return await _brandCollection.CountDocumentsAsync(FilterDefinition<Entities.Brand>.Empty);
        }
      
        public async Task<long> GetCategoryCount()
        {
            return await _categoryCollection.CountDocumentsAsync(FilterDefinition<Eshop.Category.Entities.Category>.Empty);
        }
       
        public async Task<decimal> GetProductAvgPrice()
        {
            var pipeline = new BsonDocument[]
            {
                new BsonDocument($"group",new BsonDocument
                {
                    {"_id",null },
                    { "averagePrice" , new BsonDocument ($"avg","ProductPrice")}
                })
            };
            var result = await _productCollection.AggregateAsync<BsonDocument>(pipeline);
            return result.FirstOrDefault().GetValue("averagePrice", decimal.Zero).AsDecimal;    
        }

        public async Task<long> GetProductCount()
        {
            return await _productCollection.CountDocumentsAsync(FilterDefinition<Product>.Empty);

        }

        public async Task<string> GetProductMaxPrice()
        {
            var filter = Builders<Product>.Filter.Empty;
            var sort = Builders<Product>.Sort.Descending(x => x.ProductPrice);
            var projection = Builders<Product>.Projection.Include(y=>y.ProductName).Exclude("ProductId");
            var product = await _productCollection.Find(filter).Sort(sort).Project(projection).FirstOrDefaultAsync();
            return product.GetValue("ProductName").AsString;
        }

        public async Task<string> GetProductMinPrice()
        {
            var filter = Builders<Product>.Filter.Empty;
            var sort = Builders<Product>.Sort.Ascending(x => x.ProductPrice);
            var projection = Builders<Product>.Projection.Include(y => y.ProductName).Exclude("ProductId");
            var product = await _productCollection.Find(filter).Sort(sort).Project(projection).FirstOrDefaultAsync();
            return product.GetValue("ProductName").AsString;
        }
    }
}
