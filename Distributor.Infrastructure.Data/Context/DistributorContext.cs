using Distributor.Infrastructure.Data.Context.Interfaces;
using MongoDB.Driver;

namespace Distributor.Infrastructure.Data.Context
{
    public class DistributorContext :IDistributorContext
    {  
        private readonly IMongoDatabase _database;

        public DistributorContext(string connectionString, string database)
        {
            var client = new MongoClient(connectionString);
            _database = client.GetDatabase(database);
        }

        public IMongoDatabase GetContext()
        {
            return _database;
        }
    }
}