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

    public async Task<string> CreateOptionRule(OptionRule model)
    {
        var mongoOptionRule = model.To();
        await Collection.InsertOneAsync(mongoOptionRule);
        return mongoOptionRule.Id;
    }

    public async Task<OptionRule> UpdateOptionRuleRuleParameters(string id, OptionRuleParameters optionRuleParameters)
    {
        var filter = Builders<MongoOptionRule>.Filter.Eq("_id",id);

        var update = Builders<MongoOptionRule>.Update
            .SetOnInsert(x => x.OptionRuleParameters, optionRuleParameters);

        var options = new FindOneAndUpdateOptions<MongoOptionRule>()
        {
            IsUpsert = true,
            ReturnDocument = ReturnDocument.After
        };
        
        var optionRule = await Collection.FindOneAndUpdateAsync(filter, update,options);

        return optionRule;
    }

    public async Task<OptionRule> UpdateOptionRuleSymbols(string id, List<string> symbols)
    {
        var filter = Builders<MongoOptionRule>.Filter.Eq("_id",id);

        var update = Builders<MongoOptionRule>.Update
            .SetOnInsert(x => x.Symbols, symbols);

        var options = new FindOneAndUpdateOptions<MongoOptionRule>()
        {
            IsUpsert = true,
            ReturnDocument = ReturnDocument.After
        };
        
        var optionRule = await Collection.FindOneAndUpdateAsync(filter, update,options);

        return optionRule;
    }

    public Task DeleteOptionRule(string id)
    {
        throw new NotImplementedException();
    }
}