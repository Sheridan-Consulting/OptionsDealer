using System;
using Shared.Enums;

namespace Shared.Models
{
    public class Option
    {      
       
        public string Symbol { get; set; }
        public string Id {get;set;}
        public double StrikePrice { get; set; }
        public DateTime ExpirationDate { get; set; }        
        public int OpenInterest { get; set; }       
        public double Delta { get; set; } 
        public double Theta { get; set; } 
        public double Gamma { get; set; } 
        public double Vega { get; set; } 
        public double Bid { get; set; }
        public double Ask { get; set; }
        public double Mid { get; set; }
        public int Volume { get; set; }
         public int DaysToExpiration { get; set; }
        public bool InTheMoney { get; set; }
        public double ImpliedVolatility { get; set; }
        public OptionType Type {get;set;}

    }
}