using Data.Entities;
using MongoDB.Driver;
using Shared.Repositories;

namespace Data.Repository;

public class MongoRepository<T> : IRepository<T>
{
    public readonly IMongoCollection<T> Collection;

    public MongoRepository(IMongoDatabase database,string collectionName)
    {
        Collection = database.GetCollection<T>(collectionName);
    }
    
    public IQueryable<T> GetAll()
    {
        return Collection.AsQueryable();
    }

    public async Task Add(T obj)
    {
        await Collection.InsertOneAsync(obj);
    }
    
}