using Microsoft.Extensions.Options;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using Shared.Models.Configuration;

namespace Data;

public class MongoDbContext
{
    private MongoClient _client;
    private IMongoDatabase _database;
    
    public MongoDbContext(IOptions<OptionTraderDatabaseSettings> optionTraderDatabaseSettings)
    {
        Setup(optionTraderDatabaseSettings.Value);
    }

    public MongoDbContext(OptionTraderDatabaseSettings settings)
    {
        Setup(settings);
    }

    private void Setup(OptionTraderDatabaseSettings settings)
    {
        _client = new MongoClient(settings.ConnectionString);
        _database = _client.GetDatabase(settings.DatabaseName);
    }
    public IMongoClient Client => _client;

    public IMongoDatabase Database => _database;
}