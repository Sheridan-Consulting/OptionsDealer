using System;
using System.Collections.Generic;
using Shared.Enums;
using Shared.Interfaces;
using Shared.Models;
using Shared.Models.Configuration;

namespace Shared.Services
{
    public class OptionTrader : IOptionTrader
    {
        public OptionTrader()
        {
        }

        public OptionTransaction BuyCallOptionContract(Stock stock, ContractSellCallConfiguration configuration)
        {
            throw new NotImplementedException();
        }

        public OptionTransaction BuyPutOptionContract(Stock stock, ContractSellCallConfiguration configuration)
        {
            throw new NotImplementedException();
        }

        public OptionTransaction CloseOptionContract(Stock option, ContractCloseConfiguration configuration, OptionType optionType)
        {
            throw new NotImplementedException();
        }

        public Stock SellCallOptionContract(Stock stock, ContractSellCallConfiguration configuration)
        {
            var options = new List<Option>();

            foreach (var option in stock.Options)
            {
                if (option.Type == OptionType.Call && option.StrikePrice >= (stock.Cost * configuration.StrikePricePercentageOfCost))
                {
                    options.Add(option);
                }
            }

            stock.Options = options;

            return stock;
        }

        public OptionTransaction SellPutOptionContract(Stock stock, ContractSellCallConfiguration configuration)
        {
            throw new NotImplementedException();
        }
    }
}
