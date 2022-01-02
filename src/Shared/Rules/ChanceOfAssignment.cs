using System;
using System.Collections.Generic;
using System.Linq;
using Shared.Interfaces;
using Shared.Models;

namespace Shared.Rules;

public class ChanceOfAssignment : IOptionRules
{
    private readonly double _percentage;

    public ChanceOfAssignment(double percentage)
    {
        _percentage = percentage;
    }
    public List<Option> Evaluate(Stock stock)
    {
        return stock.Options.Where(x => Math.Abs(x.Delta) < _percentage).ToList();
    }
}