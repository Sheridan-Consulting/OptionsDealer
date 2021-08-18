using System;
using System.Collections.Generic;
using Shared.Interfaces;
using Shared.Models;

namespace Shared.Services
{
    public class OptionTrader : IOptionTrader
    {
        public OptionTrader()
        {
        }

        public OptionTransaction CloseOptionContract(Stock stock, ContractCloseConfiguration configuration, OptionType optionType)
        {
            throw new NotImplementedException();
        }

        public OptionTransaction SellOptionContract(Stock stock, ContractSellConfiguration configuration, OptionType optionType)
        {
            throw new NotImplementedException();
        }
    }
}
