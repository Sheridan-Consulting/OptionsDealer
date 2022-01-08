using System.Collections.Generic;
using Shared.Models.Rules;

namespace api.Models;

public class GetOptionsToBuyWithParametersRequest
{
    public List<string> Symbols { get; set; }
    public OptionRuleParameters OptionRuleParameters { get; set; }
}