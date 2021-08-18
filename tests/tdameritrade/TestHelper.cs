using System.Collections.Generic;
using TDAmeritrade.Models.Options;

namespace Tests.TDAmeritrade
{
    public static class TestHelper
    {
        public static Option CreateOption(string callOrPut)
        {
            var option = new Option()  {
                Ask=0.52,
                AskSize=256,
                Bid=0.5,
                BidAskSize="52X256",
                BidSize=52,
                ClosePrice=0.51,
                DaysToExpiration=5,
                DeliverableNote="",
                Delta=0.34,
                Description="AAPL Jul 9 2021 138 Put (Weekly)",
                ExchangeName="OPR",
                ExpirationDate=1625860800000,
                ExpirationType="S",
                Gamma=-999,
                HighPrice=1.35,
                InTheMoney=false,
                IsIndexOption=false,
                Last=0.51,
                LastSize=0,
                LastTradingDay=1625875200000,
                LowPrice=0.5,
                Mark=0.51,
                MarkChange=0,
                MarkPercentChange=0,
                Mini=false,
                Multiplier=100,
                NetChange=0,
                NonStandard=false,
                OpenInterest=1586,
                OpenPrice=0,
                OptionDeliverablesList=null,
                PercentChange=0,
                PutCall=callOrPut,
                QuoteTimeInLong=1625255999882,
                Rho=-999,
                SettlementType="",
                StrikePrice=138,
                Symbol="AAPL",
                TheoreticalOptionValue=-1,
                TheoreticalVolatility=29,
                Theta=-999,
                TimeValue=0.51,
                TotalVolume=27921,
                TradeDate=null,
                TradeTimeInLong=1625255998883,
                Vega=-999,
                Volatility=-999            
            };

            return option;
        }
        public static OptionChain CreateOption()
        {
            var optionChain = new OptionChain()
            {
                
                DaysToExpiration=0,
                InterestRate=0.1,
                Interval=0,
                IsDelayed=true,
                IsIndex=false,
                NumberOfContracts=40,
                Status="SUCCESS",
                Strategy="SINGLE",
                Symbol="AAPL",
                Underlying=null,
                UnderlyingPrice=139.96,
                Volatility=29,
                Calls = new Dictionary<string,Dictionary<string,Option[]>>(),
                Puts = new Dictionary<string,Dictionary<string,Option[]>>()
            };

            return optionChain;
        }
    }
}