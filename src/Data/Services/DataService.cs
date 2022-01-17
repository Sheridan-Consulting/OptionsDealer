using Shared.Interfaces;
using Shared.Repositories;

namespace Data.Services;

public class DataService : IDataService
{
    private readonly MongoDbContext _dbContext;

    public DataService(MongoDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public IOptionRuleRepository OptionRuleRepository { get; }
}