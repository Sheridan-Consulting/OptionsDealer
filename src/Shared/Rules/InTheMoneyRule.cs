using System.Collections.Generic;
using System.Linq;
using Shared.Interfaces;
using Shared.Models;

namespace Shared.Rules;

public class InTheMoneyRule : IOptionRules
{
    public List<Option> Evaluate(Stock stock)
    {
        return stock.Options.Where(x => x.InTheMoney).ToList();
    }
}