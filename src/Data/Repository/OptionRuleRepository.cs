using System.Linq.Expressions;
using Data.Entities;
using Data.Extensions;
using MongoDB.Driver;
using Shared.Models.Data;
using Shared.Repositories;

namespace Data.Repository;

public class OptionRuleRepository : MongoRepository<MongoOptionRule>, IOptionRuleRepository
{
    public OptionRuleRepository(IMongoDatabase database) : base(database,
        MongoCollectionNames.OptionRule)
    {}

    public async Task<OptionRule> GetOptionRuleById(string id)
    {
        var dataModel = (await Collection.FindAsync(x => x.Id == id)).FirstOrDefaultAsync();
        return dataModel.Result.From();
    }

    public async Task<List<OptionRule>> GetOptionRulesByUserId(string userId)
    {
        var dataModel = await Collection.FindAsync(x => x.UserId == userId);
        return dataModel.ToList().FromList();
    }

    public async Task<string> CreateOptionRule(OptionRule model)
    {
        var mongoOptionRule = model.To();
        await Collection.InsertOneAsync(mongoOptionRule);
        return mongoOptionRule.Id;
    }

    public Task<OptionRule> UpdateOptionRule(string id, OptionRule model)
    {
        throw new NotImplementedException();
    }

    public Task DeleteOptionRule(string id)
    {
        throw new NotImplementedException();
    }
}