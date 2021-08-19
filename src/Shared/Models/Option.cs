using System;
using Shared.Enums;

namespace Shared.Models
{
    public class Option
    {      
       
        public string Symbol { get; set; }
        public string Id {get;set;}
        public double StrikePrice { get; init; }
        public DateTime ExpirationDate { get; init; }        
        public int OpenInterest { get; init; }       
        public double Delta { get; set; } 
        public double Theta { get; init; } 
        public double Gamma { get; init; } 
        public double Vega { get; init; } 
        public double Bid { get; set; }
        public double Ask { get; set; }
        public double Mid { get; set; }
        public int Volume { get; set; }
         public int DaysToExpiration { get; set; }
        public bool InTheMoney { get; set; }
        public double ImpliedVolatility { get; set; }
        public OptionType OptionType {get;set;}

    }
}