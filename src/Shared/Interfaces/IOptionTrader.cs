using Shared.Enums;
using Shared.Models;
using Shared.Models.Configuration;

namespace Shared.Interfaces
{
    public interface IOptionTrader
    {
        OptionTransaction SellPutOptionContract(Stock stock, ContractSellCallConfiguration configuration);
        Stock SellCallOptionContract(Stock stock, ContractSellCallConfiguration configuration);
        OptionTransaction BuyPutOptionContract(Stock stock, ContractSellCallConfiguration configuration);
        OptionTransaction BuyCallOptionContract(Stock stock, ContractSellCallConfiguration configuration);
         OptionTransaction CloseOptionContract(Stock option,ContractCloseConfiguration configuration, OptionType optionType);
    }
}
