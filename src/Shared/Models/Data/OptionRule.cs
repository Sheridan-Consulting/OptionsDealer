using System.Collections.Generic;
using Shared.Models.Rules;

namespace Shared.Models.Data;

public class OptionRule
{
    public string OptionRuleId { get; set; }
    
    public string UserId { get; set; }
    public OptionRuleParameters OptionRuleParameters { get; set; }
    public List<string> Symbols { get; set; }
}