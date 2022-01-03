using System;
using System.Linq;
using Shared.Models;
using Shared.Models.Rules;

namespace Shared.Extensions;

public static class OptionRulesExtension
{
    public static Stock RuleRunAll(this Stock stock, OptionRuleParameters parameters)
    {
        var validOptions = stock.RuleInTheMoney().RuleOpenInterest(parameters.MinOpenInterest)
            .RulePremiumPercentage(parameters.PremiumPercentage)
            .RuleChanceOfAssignment(parameters.AssignmentPercentage)
            .RuleDaysToExpiration(parameters.DaysToExpiration);

        return validOptions;
    }
    public static Stock RuleChanceOfAssignment(this Stock stock, double percentage)
    {
        stock.Options =  stock.Options.Where(x => Math.Abs(x.Delta) < percentage).ToList();
        return stock;
    }

    public static Stock RuleInTheMoney(this Stock stock)
    {
        stock.Options = stock.Options.Where(x => x.InTheMoney).ToList();
        return stock;
    }

    public static Stock RuleOpenInterest(this Stock stock, int minOpenInterest)
    {
        stock.Options =  stock.Options.Where(x => x.OpenInterest >= minOpenInterest).ToList();
        return stock;
    }

    public static Stock RulePremiumPercentage(this Stock stock, double percentage)
    {
        stock.Options =  stock.Options.Where(x => x.Mid >= (x.StrikePrice * percentage)).ToList();
        return stock;
    }

    public static Stock RuleDaysToExpiration(this Stock stock, int daysToExpiration)
    {
        stock.Options = stock.Options.Where(x => x.DaysToExpiration < daysToExpiration).ToList();
        return stock;
    }
}