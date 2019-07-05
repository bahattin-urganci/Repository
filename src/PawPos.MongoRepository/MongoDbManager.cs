using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace PawPos.MongoRepository
{
    public class MongoDbManager
    {
        //TODO driver codes will be written about db management
        private IMongoDatabase _db;
        public MongoDbManager(IOptions<MongoDbSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            if (client != null)
                _db = client.GetDatabase(settings.Value.Database);
        }
    }
}
