using System.Collections.Generic;
using Shared.Models;

namespace Tests.Shared
{
    public class OptionSampleData
    {
        /*
        public OptionSampleData()
        {
            Stock = new Stock() { Symbol="AMC" };            

            for(int i=1;i<20;i++)
            {
                Stock.Options.Add(
                    new Option(){
                        ExpirationDate=new System.DateTime(2022,1,22),
                        Delta=1-(i*.1),
                        StrikePrice=i,
                        Premium=21.0-i
                    });                  
            }
        }
        */
        public Stock Stock{get;set;}
    }
}