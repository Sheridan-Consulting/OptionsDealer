using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Ally.Models
{
    public class Strike
    {
        [JsonPropertyName("ask")] public string Ask { get; set; }

        [JsonPropertyName("ask_time")] public string AskTime { get; set; }

        [JsonPropertyName("asksz")] public string Asksz { get; set; }

        [JsonPropertyName("basis")] public string Basis { get; set; }

        [JsonPropertyName("bid")] public string Bid { get; set; }

        [JsonPropertyName("bid_time")] public string BidTime { get; set; }

        [JsonPropertyName("bidsz")] public string Bidsz { get; set; }

        [JsonPropertyName("chg")] public string Chg { get; set; }

        [JsonPropertyName("chg_sign")] public string ChgSign { get; set; }

        [JsonPropertyName("chg_t")] public string ChgT { get; set; }

        [JsonPropertyName("cl")] public string Cl { get; set; }

        [JsonPropertyName("contract_size")] public string ContractSize { get; set; }

        [JsonPropertyName("date")] public string Date { get; set; }

        [JsonPropertyName("datetime")] public DateTime Datetime { get; set; }

        [JsonPropertyName("days_to_expiration")]
        public string DaysToExpiration { get; set; }

        [JsonPropertyName("exch")] public string Exch { get; set; }

        [JsonPropertyName("exch_desc")] public string ExchDesc { get; set; }

        [JsonPropertyName("hi")] public string Hi { get; set; }

        [JsonPropertyName("incr_vl")] public string IncrVl { get; set; }

        [JsonPropertyName("issue_desc")] public string IssueDesc { get; set; }

        [JsonPropertyName("last")] public string Last { get; set; }

        [JsonPropertyName("lo")] public string Lo { get; set; }

        [JsonPropertyName("op_delivery")] public string OpDelivery { get; set; }

        [JsonPropertyName("op_flag")] public string OpFlag { get; set; }

        [JsonPropertyName("op_style")] public string OpStyle { get; set; }

        [JsonPropertyName("op_subclass")] public string OpSubclass { get; set; }

        [JsonPropertyName("opn")] public string Opn { get; set; }

        [JsonPropertyName("pchg")] public string Pchg { get; set; }

        [JsonPropertyName("pchg_sign")] public string PchgSign { get; set; }

        [JsonPropertyName("pcls")] public string Pcls { get; set; }

        [JsonPropertyName("phi")] public string Phi { get; set; }

        [JsonPropertyName("plo")] public string Plo { get; set; }

        [JsonPropertyName("popn")] public string Popn { get; set; }

        [JsonPropertyName("pr_date")] public string PrDate { get; set; }

        [JsonPropertyName("pr_openinterest")] public string PrOpeninterest { get; set; }

        [JsonPropertyName("prchg")] public string Prchg { get; set; }

        [JsonPropertyName("prem_mult")] public string PremMult { get; set; }

        [JsonPropertyName("put_call")] public string PutCall { get; set; }

        [JsonPropertyName("pvol")] public string Pvol { get; set; }

        [JsonPropertyName("rootsymbol")] public string Symbol { get; set; }

        [JsonPropertyName("secclass")] public string Secclass { get; set; }

        [JsonPropertyName("sesn")] public string Sesn { get; set; }

        [JsonPropertyName("strikeprice")] public string Strikeprice { get; set; }

        [JsonPropertyName("symbol")] public string OptionSymbol { get; set; }

        [JsonPropertyName("tcond")] public string Tcond { get; set; }

        [JsonPropertyName("timestamp")] public string Timestamp { get; set; }

        [JsonPropertyName("tr_num")] public string TrNum { get; set; }

        [JsonPropertyName("tradetick")] public string Tradetick { get; set; }

        [JsonPropertyName("under_cusip")] public string UnderCusip { get; set; }

        [JsonPropertyName("undersymbol")] public string Undersymbol { get; set; }

        [JsonPropertyName("vl")] public string Vl { get; set; }

        [JsonPropertyName("vwap")] public string Vwap { get; set; }

        [JsonPropertyName("wk52hi")] public string Wk52hi { get; set; }

        [JsonPropertyName("wk52hidate")] public string Wk52hidate { get; set; }

        [JsonPropertyName("wk52lo")] public string Wk52lo { get; set; }

        [JsonPropertyName("wk52lodate")] public string Wk52lodate { get; set; }

        [JsonPropertyName("xdate")] public string Xdate { get; set; }

        [JsonPropertyName("xday")] public string Xday { get; set; }

        [JsonPropertyName("xmonth")] public string Xmonth { get; set; }

        [JsonPropertyName("xyear")] public string Xyear { get; set; }

        [JsonPropertyName("imp_Volatility")] public string ImpVolatility { get; set; }

        [JsonPropertyName("idelta")] public string Idelta { get; set; }

        [JsonPropertyName("igamma")] public string Igamma { get; set; }

        [JsonPropertyName("itheta")] public string Itheta { get; set; }

        [JsonPropertyName("ivega")] public string Ivega { get; set; }

        [JsonPropertyName("irho")] public string Irho { get; set; }

        [JsonPropertyName("openinterest")] public string Openinterest { get; set; }

    }
}

