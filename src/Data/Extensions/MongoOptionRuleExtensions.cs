using Data.Entities;
using Shared.Models.Data;

namespace Data.Extensions;

public static class MongoOptionRuleExtensions
{
    public static OptionRule From(this MongoOptionRule mongoOptionRule)
    {
        return new OptionRule()
        {
            OptionRuleId = mongoOptionRule.Id,
            Symbols = mongoOptionRule.Symbols,
            UserId = mongoOptionRule.UserId,
            OptionRuleParameters = mongoOptionRule.OptionRuleParameters
        };
    }

    public static MongoOptionRule To(this OptionRule optionRule)
    {
        return new MongoOptionRule()
        {
            Symbols = optionRule.Symbols,
            UserId = optionRule.UserId,
            OptionRuleParameters = optionRule.OptionRuleParameters
        };
    }

    public static List<OptionRule>? FromList(this IEnumerable<MongoOptionRule> mongoOptionRules)
    {
        var optionRules = new List<OptionRule>();
        foreach (var mongoOptionRule in mongoOptionRules)
        {
            optionRules.Add(mongoOptionRule.From());
        }

        return optionRules;
    }
}