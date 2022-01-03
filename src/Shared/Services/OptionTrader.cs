using System;
using System.Collections.Generic;
using Shared.Enums;
using Shared.Extensions;
using Shared.Interfaces;
using Shared.Models;
using Shared.Models.Configuration;
using Shared.Models.Rules;

namespace Shared.Services
{
    public class OptionTrader : IOptionTrader
    {
        private readonly IBrokerageService _brokerageService;

        public OptionTrader(IBrokerageService brokerageService)
        {
            _brokerageService = brokerageService;
        }
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

        public Stock FindOptionsToBuy(Stock stock, OptionRuleParameters parameters)
        {
            return stock.RuleRunAll(parameters);
        }

        public Stock GetAllStockInfo(string symbol)
        {
            return _brokerageService.GetOptionsInfo(symbol, 2022, 1);
        }

        public OptionTransaction SellPutOptionContract(Stock stock, ContractSellCallConfiguration configuration)
        {
            throw new NotImplementedException();
        }
    }
}
