using System;
using System.Linq;
using Shared.Enums;
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
            .RuleDaysToExpiration(parameters.DaysToExpiration)
            .RuleMinPremium(parameters.MinimumPremium)
            .RuleOptionType(parameters.Calls, parameters.Puts);

        return validOptions;
    }

    public static Stock RuleOptionType(this Stock stock,bool calls,bool puts)
    {
        if (calls && puts) return stock;
        
        if (calls) stock.Options =  stock.Options.Where(x => x.Type == OptionType.Call).ToList();
        else if (puts) stock.Options =  stock.Options.Where(x => x.Type == OptionType.Put).ToList();

        return stock;
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

    public static Stock RuleMinPremium(this Stock stock,double minimumPremium)
    {
        stock.Options = stock.Options.Where(x => x.Mid >= minimumPremium).ToList();
        return stock;
    }

    public static Stock RuleOpenInterest(this Stock stock, int minOpenInterest)
    {
        stock.Options =  stock.Options.Where(x => x.OpenInterest >= minOpenInterest).ToList();
        return stock;
    }

    public static Stock RulePremiumPercentage(this Stock stock, double percentage)
    {
        stock.Options =  stock.Options.Where(x => x.Mid >= (x.StrikePrice * (percentage/100))).ToList();
        return stock;
    }

    public static Stock RuleDaysToExpiration(this Stock stock, int daysToExpiration)
    {
        stock.Options = stock.Options.Where(x => x.DaysToExpiration < daysToExpiration).ToList();
        return stock;
    }
}