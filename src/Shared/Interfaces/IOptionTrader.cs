using System.Collections.Generic;
using Shared.Models;

namespace Shared.Interfaces
{
    public interface IOptionTrader
    {
         OptionTransaction SellOptionContract(Stock stock,ContractSellConfiguration configuration,OptionType optionType);
         OptionTransaction CloseOptionContract(Stock option,ContractCloseConfiguration configuration, OptionType optionType);
    }
}
