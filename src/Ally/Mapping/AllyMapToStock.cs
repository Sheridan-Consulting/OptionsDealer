using System.Globalization;
using Ally.Models;
using Ally.Models.Stocks;
using Shared.Enums;
using Shared.Models;

namespace Ally.Mapping;

public class AllyMapToStock
{
    private readonly AllyOptionChain _optionResponse;
    private readonly AllyStockChain _stockResponse;

    public AllyMapToStock(AllyOptionChain optionResponse,AllyStockChain stockResponse)
    {
        _optionResponse = optionResponse;
        _stockResponse = stockResponse;
    }

    public Stock ToStock()
    {
        var strikes = _optionResponse.Response.Quotes.Strikes;
        var stocks = _stockResponse.Response.Quotes.Stock;
        var stock = new Stock
        {
            Symbol = strikes.First().Symbol,
            Price = Convert.ToDouble(stocks.Last)
        };

        foreach (var strike in strikes)
        {
            stock.Options.Add( new Option()
            {
                Ask = Convert.ToDouble(strike.Ask),
                Bid = Convert.ToDouble(strike.Bid),
                Delta = Convert.ToDouble(strike.Delta),
                Gamma = Convert.ToDouble(strike.Gamma),
                Id = strike.OptionSymbol,
                Mid = Convert.ToDouble(strike.LastPrice),
                Symbol = strikes.First().Symbol,
                Theta = Convert.ToDouble(strike.Theta),
                Vega = Convert.ToDouble(strike.Vega),
                Volume = Convert.ToInt32(strike.CumulativeVolume),
                ExpirationDate = DateTime.ParseExact(strike.ExpriationDate, "yyyyMMdd",CultureInfo.InvariantCulture),
                ImpliedVolatility = Convert.ToDouble(strike.ImpliedVolatily),
                OpenInterest = Convert.ToInt32(strike.OpenInterest),
                StrikePrice = Convert.ToDouble(strike.StrikePrice),
                DaysToExpiration = Convert.ToInt32(strike.DaysToExpiration),
                Type = (strike.PutOrCall == "call" ? OptionType.Call : OptionType.Put),
                InTheMoney = !(Convert.ToDouble(strike.StrikePrice) > stock.Price.Value)
            });
        }

        return stock;
    }
}