using System.Collections.Generic;
using Shared.Models;

namespace Tests.Shared.Rules;

public class RulesTestBase
{
    protected Stock Stock;

    protected RulesTestBase()
    {
        Stock = new Stock()
        {
            Price = 50.0,
            Symbol = "AAPL",
            Options = new List<Option>()
        };
    }
   
}