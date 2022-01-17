using System.Collections.Generic;
using System.Threading.Tasks;
using Shared.Models.Data;
using Shared.Models.Rules;

namespace Shared.Repositories;

public interface IOptionRuleRepository 
{
    Task<OptionRule> GetOptionRuleById(string id);
    Task<List<OptionRule>> GetOptionRulesByUserId(string userId);

    Task<string> CreateOptionRule(OptionRule model);

    Task<OptionRule> UpdateOptionRuleSymbols(string id, List<string> model);
    Task<OptionRule> UpdateOptionRuleRuleParameters(string id, OptionRuleParameters optionRuleParameters);
    Task DeleteOptionRule(string id);
}