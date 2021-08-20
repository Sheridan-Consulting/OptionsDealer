using System.Security.Permissions;
using AutoFixture.Xunit2;
using Shared.Models;
using Shared.Services;
using Shared.Enums;
using Xunit;
using Shared.Models.Configuration;

namespace Tests.Shared.Interfaces.IOptionTrader
{
    
    public class SellCallOptionContract
    {    
        private readonly Stock _stock;     
        public SellCallOptionContract()
        {
            _stock = new Stock(){
                Symbol = "AAPL",
                Price = 100,
                Cost=90
            };
            
        } 

        [Theory,AutoData]
        public void Should_Return_One_Options(Option option1)
        {   
            ContractSellCallConfiguration config = new(){
                StrikePricePercentageOfCost=1.1
            };

            option1.StrikePrice = 100;
            option1.Type = OptionType.Call;
            option1.Delta=.2;
            option1.Bid=.1;
            option1.DaysToExpiration = 10;

            _stock.Options.Add(option1);


            var optionTrader = new OptionTrader();
            var stock = optionTrader.SellCallOptionContract(_stock,config);

            Assert.Single(stock.Options);
        }        
    }
}