using Shared.Interfaces;
using Shared.Models;
using Shared.Models.Configuration;

namespace Ally;

public class AllyBrokerageService : IBrokerageService
{
    public Stock GetOptionsInfo(string symbol, int year, int month)
    {
        var options = new List<Option>();
        var option = new Option()
            {Mid = .33, StrikePrice = 29, InTheMoney = true, Delta = -.1486, OpenInterest = 2978};
        options.Add(option);
        var stock = new Stock() {Symbol = symbol,Price = 32.0,Options = options};
        
        
        return stock;
    }
}