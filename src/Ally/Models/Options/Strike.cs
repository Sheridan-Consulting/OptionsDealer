using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Ally.Models
{
    public class Strike
    {
        [JsonPropertyName("ask")] public string Ask { get; set; }

        [JsonPropertyName("ask_time")] public string AskTime { get; set; }

        [JsonPropertyName("asksz")] public string AskSize { get; set; }

        [JsonPropertyName("basis")] public string Basis { get; set; }

        [JsonPropertyName("bid")] public string Bid { get; set; }

        [JsonPropertyName("bid_time")] public string BidTime { get; set; }

        [JsonPropertyName("bidsz")] public string BidSize { get; set; }

        [JsonPropertyName("chg")] public string ChangeSincePriorDayClose { get; set; }

        [JsonPropertyName("chg_sign")] public string ChangeSign { get; set; }

        [JsonPropertyName("chg_t")] public string ChangeSincePriorDayCloseText { get; set; }

        [JsonPropertyName("cl")] public string PreviousClose { get; set; }

        [JsonPropertyName("contract_size")] public string ContractSize { get; set; }

        [JsonPropertyName("date")] public string Date { get; set; }

        [JsonPropertyName("datetime")] public DateTime Datetime { get; set; }

        [JsonPropertyName("days_to_expiration")]
        public string DaysToExpiration { get; set; }

        [JsonPropertyName("exch")] public string ExchangeCode { get; set; }

        [JsonPropertyName("exch_desc")] public string ExchangeDescription { get; set; }

        [JsonPropertyName("hi")] public string HighTradePriceForDay { get; set; }

        [JsonPropertyName("incr_vl")] public string VolumeOfLastTrade { get; set; }

        [JsonPropertyName("issue_desc")] public string IssueDescription { get; set; }

        [JsonPropertyName("last")] public string LastPrice { get; set; }

        [JsonPropertyName("lo")] public string LowTradePriceForDay { get; set; }

        [JsonPropertyName("op_delivery")] public string OptionSettlementDesignation  { get; set; }

        [JsonPropertyName("op_flag")] public string HasOption { get; set; }

        [JsonPropertyName("op_style")] public string OptionStyle { get; set; }

        [JsonPropertyName("op_subclass")] public string OpSubclass { get; set; }

        [JsonPropertyName("opn")] public string OpenTradePrice { get; set; }

        [JsonPropertyName("pchg")] public string PercentChangeFromPriorDay { get; set; }

        [JsonPropertyName("pchg_sign")] public string PriorDayChangeSignal { get; set; }

        [JsonPropertyName("pcls")] public string PriorDayClose { get; set; }

        [JsonPropertyName("phi")] public string PriorDayHigh { get; set; }

        [JsonPropertyName("plo")] public string PriorDayLow { get; set; }

        [JsonPropertyName("popn")] public string PriorDayOpen { get; set; }

        [JsonPropertyName("pr_date")] public string PriorDate { get; set; }

        [JsonPropertyName("pr_openinterest")] public string PriorDayOpenInterest { get; set; }

        [JsonPropertyName("prchg")] public string PriorDayChange { get; set; }

        [JsonPropertyName("prem_mult")] public string PremiumMultiplier { get; set; }

        [JsonPropertyName("put_call")] public string PutOrCall { get; set; }

        [JsonPropertyName("pvol")] public string PriorDayTotalVolume { get; set; }

        [JsonPropertyName("rootsymbol")] public string Symbol { get; set; }

        [JsonPropertyName("secclass")] public string SecurityClass { get; set; }

        [JsonPropertyName("sesn")] public string Sesn { get; set; }

        [JsonPropertyName("strikeprice")] public string StrikePrice { get; set; }

        [JsonPropertyName("symbol")] public string OptionSymbol { get; set; }

        [JsonPropertyName("tcond")] public string Tcond { get; set; }

        [JsonPropertyName("timestamp")] public string Timestamp { get; set; }

        [JsonPropertyName("tr_num")] public string NumberOfTradesSinceMarketOpen { get; set; }

        [JsonPropertyName("tradetick")] public string TickDirectionFromPriorTrade { get; set; }

        [JsonPropertyName("under_cusip")] public string UnderlyingCusip { get; set; }

        [JsonPropertyName("undersymbol")] public string UnderlyingSymbol { get; set; }

        [JsonPropertyName("vl")] public string CumulativeVolume { get; set; }

        [JsonPropertyName("vwap")] public string VolumeWeightedAveragePrice { get; set; }

        [JsonPropertyName("wk52hi")] public string Wk52hi { get; set; }

        [JsonPropertyName("wk52hidate")] public string Wk52hidate { get; set; }

        [JsonPropertyName("wk52lo")] public string Wk52lo { get; set; }

        [JsonPropertyName("wk52lodate")] public string Wk52lodate { get; set; }

        [JsonPropertyName("xdate")] public string ExpriationDate { get; set; }

        [JsonPropertyName("xday")] public string ExpirationDay { get; set; }

        [JsonPropertyName("xmonth")] public string ExperiationMonth { get; set; }

        [JsonPropertyName("xyear")] public string ExperationYear { get; set; }

        [JsonPropertyName("imp_Volatility")] public string ImpliedVolatily { get; set; }

        [JsonPropertyName("idelta")] public string Delta { get; set; }

        [JsonPropertyName("igamma")] public string Gamma { get; set; }

        [JsonPropertyName("itheta")] public string Theta { get; set; }

        [JsonPropertyName("ivega")] public string Vega { get; set; }

        [JsonPropertyName("irho")] public string RHO { get; set; }

        [JsonPropertyName("openinterest")] public string OpenInterest { get; set; }

    }
}

