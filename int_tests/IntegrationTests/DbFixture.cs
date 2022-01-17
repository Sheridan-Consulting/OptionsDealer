using System;
using System.Threading.Tasks;
using Data;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Shared.Models.Configuration;


namespace IntegrationTests
{
    public class DbFixture : IDisposable
    {
        public DbFixture()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            var connString = config.GetConnectionString("db");
            var dbName = $"test_db_{Guid.NewGuid()}";

            OptionTraderDatabaseSettings  = new OptionTraderDatabaseSettings()
            {
                ConnectionString = connString,
                DatabaseName = dbName
            };
            var dbContext = new MongoDbContext(OptionTraderDatabaseSettings);
            Database = dbContext.Database;
        }

        public OptionTraderDatabaseSettings OptionTraderDatabaseSettings { get; }
        public IMongoDatabase Database { get; }

        public void Dispose()
        { 
           // var client = new MongoClient(this.OptionTraderDatabaseSettings.ConnectionString);
          // client.DropDatabase(this.OptionTraderDatabaseSettings.DatabaseName);
        }
    }
}