namespace TDAmeritrade.Models.Options
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Text.Json;
    using System.Text.Json.Serialization;
    

    public partial class OptionChain
    {
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("underlying")]
        public object Underlying { get; set; }

        [JsonPropertyName("strategy")]
        public string Strategy { get; set; }

        [JsonPropertyName("interval")]
        public long Interval { get; set; }

        [JsonPropertyName("isDelayed")]
        public bool IsDelayed { get; set; }

        [JsonPropertyName("isIndex")]
        public bool IsIndex { get; set; }

        [JsonPropertyName("interestRate")]
        public double InterestRate { get; set; }

        [JsonPropertyName("underlyingPrice")]
        public double UnderlyingPrice { get; set; }

        [JsonPropertyName("volatility")]
        public long Volatility { get; set; }

        [JsonPropertyName("daysToExpiration")]
        public long DaysToExpiration { get; set; }

        [JsonPropertyName("numberOfContracts")]
        public long NumberOfContracts { get; set; }

        [JsonPropertyName("putExpDateMap")]
        public Dictionary<string, Dictionary<string, Option[]>> Puts { get; set; }

        [JsonPropertyName("callExpDateMap")]
        public Dictionary<string, Dictionary<string, Option[]>> Calls { get; set; }
    }

    public partial class Option
    {
        [JsonPropertyName("putCall")]
        public string PutCall { get; set; }

        [JsonPropertyName("symbol")]
        public string Symbol { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("exchangeName")]
        public string ExchangeName { get; set; }

        [JsonPropertyName("bid")]
        public double Bid { get; set; }

        [JsonPropertyName("ask")]
        public double Ask { get; set; }

        [JsonPropertyName("last")]
        public double Last { get; set; }

        [JsonPropertyName("mark")]
        public double Mark { get; set; }

        [JsonPropertyName("bidSize")]
        public long BidSize { get; set; }

        [JsonPropertyName("askSize")]
        public long AskSize { get; set; }

        [JsonPropertyName("bidAskSize")]
        public string BidAskSize { get; set; }

        [JsonPropertyName("lastSize")]
        public long LastSize { get; set; }

        [JsonPropertyName("highPrice")]
        public double HighPrice { get; set; }

        [JsonPropertyName("lowPrice")]
        public double LowPrice { get; set; }

        [JsonPropertyName("openPrice")]
        public long OpenPrice { get; set; }

        [JsonPropertyName("closePrice")]
        public double ClosePrice { get; set; }

        [JsonPropertyName("totalVolume")]
        public long TotalVolume { get; set; }

        [JsonPropertyName("tradeDate")]
        public object TradeDate { get; set; }

        [JsonPropertyName("tradeTimeInLong")]
        public long TradeTimeInLong { get; set; }

        [JsonPropertyName("quoteTimeInLong")]
        public long QuoteTimeInLong { get; set; }

        [JsonPropertyName("netChange")]
        public long NetChange { get; set; }

        [JsonPropertyName("volatility")]
        public long Volatility { get; set; }

        [JsonPropertyName("delta")]
        public double Delta { get; set; }

        [JsonPropertyName("gamma")]
        public long Gamma { get; set; }

        [JsonPropertyName("theta")]
        public long Theta { get; set; }

        [JsonPropertyName("vega")]
        public long Vega { get; set; }

        [JsonPropertyName("rho")]
        public long Rho { get; set; }

        [JsonPropertyName("openInterest")]
        public long OpenInterest { get; set; }

        [JsonPropertyName("timeValue")]
        public double TimeValue { get; set; }

        [JsonPropertyName("theoreticalOptionValue")]
        public long TheoreticalOptionValue { get; set; }

        [JsonPropertyName("theoreticalVolatility")]
        public long TheoreticalVolatility { get; set; }

        [JsonPropertyName("optionDeliverablesList")]
        public object OptionDeliverablesList { get; set; }

        [JsonPropertyName("strikePrice")]
        public long StrikePrice { get; set; }

        [JsonPropertyName("expirationDate")]
        public long ExpirationDate { get; set; }

        [JsonPropertyName("daysToExpiration")]
        public long DaysToExpiration { get; set; }

        [JsonPropertyName("expirationType")]
        public string ExpirationType { get; set; }

        [JsonPropertyName("lastTradingDay")]
        public long LastTradingDay { get; set; }

        [JsonPropertyName("multiplier")]
        public long Multiplier { get; set; }

        [JsonPropertyName("settlementType")]
        public string SettlementType { get; set; }

        [JsonPropertyName("deliverableNote")]
        public string DeliverableNote { get; set; }

        [JsonPropertyName("isIndexOption")]
        public object IsIndexOption { get; set; }

        [JsonPropertyName("percentChange")]
        public long PercentChange { get; set; }

        [JsonPropertyName("markChange")]
        public double MarkChange { get; set; }

        [JsonPropertyName("markPercentChange")]
        public double MarkPercentChange { get; set; }

        [JsonPropertyName("nonStandard")]
        public bool NonStandard { get; set; }

        [JsonPropertyName("inTheMoney")]
        public bool InTheMoney { get; set; }

        [JsonPropertyName("mini")]
        public bool Mini { get; set; }
    }

}
