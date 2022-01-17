using System.Collections.Generic;
using System.Threading.Tasks;
using Shared.Models.Data;

namespace Shared.Repositories;

public interface IOptionRuleRepository 
{
    Task<OptionRule> GetOptionRuleById(string id);
    Task<List<OptionRule>> GetOptionRulesByUserId(string userId);

    Task<string> CreateOptionRule(OptionRule model);

    Task<OptionRule> UpdateOptionRule(string id, OptionRule model);
    Task DeleteOptionRule(string id);
}