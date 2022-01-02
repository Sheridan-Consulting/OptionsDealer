using System;
using System.Linq;
using Shared.Models;

namespace Shared.Extensions;

public static class OptionRulesExtension
{
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
        stock.Options =  stock.Options.Where(x => x.Mid > (x.StrikePrice * percentage)).ToList();
        return stock;
    }
}