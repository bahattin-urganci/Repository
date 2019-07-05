using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using PawPos.Domain;
using PawPos.Infrastructure;
using PawPos.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PawPos.MongoRepository
{
    public class MongoRepository<T> : IDbManager, IRepository<T> where T : BaseEntity
    {
        private IMongoDatabase _db;
        public MongoRepository()
        {

        }
        public MongoRepository(IOptions<MongoDbSettings> settings)
        {
            SetConnection(settings.Value);
        }

        public void SetConnection(IDbSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            if (client != null)
                _db = client.GetDatabase(settings.Database);
        }

        private IMongoCollection<T> GetCollection() => _db.GetCollection<T>(typeof(T).Name);
        bool IRepository<T>.CollectionExists()
        {
            var filter = new BsonDocument();
            var totalCount = GetCollection().CountDocuments(filter);
            return totalCount > 0;
        }
        public async Task<bool> ExistsAsync(string id)
        {
            var query = new BsonDocument("_id", id);
            var cursor = GetCollection().Find(query);
            var count = await cursor.CountDocumentsAsync();
            return (count > 0);
        }
        public bool Exists(Expression<Func<T, bool>> expression) => GetCollection().CountDocuments<T>(expression) != 0;
        public async Task<string> UpdateAsync(T entity)
        {
            var existing = await GetAsync(x => x.Id == entity.Id);
            entity.UpdateDate = DateTime.Now;
            entity.RecordDate = existing.RecordDate;
            await GetCollection().FindOneAndReplaceAsync(Builders<T>.Filter.Eq(x => x.Id, entity.Id), entity);
            return entity.Id;
        }

        public async Task<string> AddAsync(T entity)
        {
            entity.Id = ObjectId.GenerateNewId().ToString();
            entity.RecordDate = DateTime.Now;
            await GetCollection().InsertOneAsync(entity);
            return entity.Id;
        }
        public async Task AddRangeAsync(IEnumerable<T> entities) => await GetCollection().InsertManyAsync(entities);
        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate) => await GetCollection().Find(predicate).ToListAsync();
        public async Task<T> GetAsync(Expression<Func<T, bool>> expression) => await GetCollection().Find(expression).FirstOrDefaultAsync();
        public async Task<IEnumerable<T>> GetAllAsync() => await GetCollection().Find(new BsonDocument()).ToListAsync();
        public async Task RemoveAsync(T entity) => await GetCollection().DeleteOneAsync(Builders<T>.Filter.Eq(x => x.Id, entity.Id));
        public async Task RemoveRangeAsync(IEnumerable<T> entities) => await GetCollection().DeleteManyAsync(Builders<T>.Filter.In("Id", entities.Select(x => x.Id)));
        public async Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> predicate) => await GetCollection().Find(predicate).SingleOrDefaultAsync();
        public Task<string> SaveAsync(T entity) => string.IsNullOrEmpty(entity.Id) ? AddAsync(entity) : UpdateAsync(entity);


    }
}
