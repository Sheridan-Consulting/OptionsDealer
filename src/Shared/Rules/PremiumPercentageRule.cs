using System.Collections.Generic;
using System.Linq;
using Shared.Interfaces;
using Shared.Models;

namespace Shared.Rules;

public class PremiumPercentageRule : IOptionRules
{
    private readonly double _percentage;

    public PremiumPercentageRule(double percentage)
    {
        _percentage = percentage;
    }

    public List<Option> Evaluate(Stock stock)
    {
        return stock.Options.Where(x => x.Mid > (x.StrikePrice * _percentage)).ToList();
    }
}