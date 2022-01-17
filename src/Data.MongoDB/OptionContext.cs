using System;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Data.MongoDB
{
    
    public class OptionContext
    {
        private readonly IMongoDatabase _database;

        public OptionContext(IOptions<OptionSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            if (client != null)
                _database = client.GetDatabase(settings.Value.Database);
        }

        public IMongoCollection<OptionTransaction> OptionTransactions => _database.GetCollection<OptionTransaction>("OptionTransactions");    
    }
}
