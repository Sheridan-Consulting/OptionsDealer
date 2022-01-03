using Shared.Enums;
using Shared.Models;
using Shared.Models.Configuration;
using Shared.Models.Rules;

namespace Shared.Interfaces
{
    public interface IOptionTrader
    {
        Stock FindOptionsToBuy(Stock stock, OptionRuleParameters parameters);
        Stock FindOptionsToBuy(Stock stock);
        Stock GetAllStockInfo(string symbol);
        OptionTransaction SellPutOptionContract(Stock stock, ContractSellCallConfiguration configuration);
        Stock SellCallOptionContract(Stock stock, ContractSellCallConfiguration configuration);
        OptionTransaction BuyPutOptionContract(Stock stock, ContractSellCallConfiguration configuration);
        OptionTransaction BuyCallOptionContract(Stock stock, ContractSellCallConfiguration configuration);
         OptionTransaction CloseOptionContract(Stock option,ContractCloseConfiguration configuration, OptionType optionType);
    }
}
