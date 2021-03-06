using TDAmeritrade.Models.Options;
using Shared.Models;
using Shared.Enums;

namespace TDAmeritrade.Mappings
{
    public class OptionChainToStock
    {
        private readonly OptionChain _optionChain;        
        public OptionChainToStock(OptionChain optionChain)
        {            
            this._optionChain = optionChain;

        }

        public Stock MapToStock()
        {
            var stock = new Stock
            {
                Symbol = _optionChain.Symbol,
                Price = _optionChain.UnderlyingPrice
            };

            foreach (var expDate in _optionChain.Puts)
            {                
                foreach(var stikePrice in expDate.Value){
                    foreach(var option in stikePrice.Value){
                        var optionAdd = new Shared.Models.Option(){
                            Id=option.Symbol,
                            Type = OptionType.Put,
                            Delta=option.Delta,
                            Vega=option.Vega,
                            ImpliedVolatility=option.Volatility,
                            Mid=option.Mark
                        };
                        stock.Options.Add(optionAdd);
                    }
                }
            }

            return stock;
        }
    }
}