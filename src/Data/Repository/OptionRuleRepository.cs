using System.Linq.Expressions;
using Data.Entities;
using Data.Extensions;
using MongoDB.Driver;
using Shared.Models.Data;
using Shared.Models.Rules;
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

    public async Task<OptionRule> CreateOptionRule(OptionRule model)
    {
        var mongoOptionRule = model.To();
        await Collection.InsertOneAsync(mongoOptionRule);
        return mongoOptionRule.From();
    }

    public async Task<OptionRule> UpdateOptionRule(string id, OptionRule optionRule)
    {
        optionRule.OptionRuleId = id;
        var dataModel = optionRule.To();
        
        var result = await Collection.ReplaceOneAsync(x => x.Id == id, dataModel);
        
        return optionRule;
    }

   

    public async Task DeleteOptionRule(string id)
    {
        await Collection.DeleteOneAsync(x => x.Id == id);
    }
}