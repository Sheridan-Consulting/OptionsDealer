using System.Collections.Generic;
using System.Linq;
using Shared.Interfaces;
using Shared.Models;

namespace Shared.Rules;

public class OpenInterestRule : IOptionRules
{
    private readonly int _minOpenInterest;

    public OpenInterestRule(int minOpenInterest)
    {
        _minOpenInterest = minOpenInterest;
    }

    public List<Option> Evaluate(Stock stock)
    {
        return stock.Options.Where(x => x.OpenInterest >= _minOpenInterest).ToList();
    }
}