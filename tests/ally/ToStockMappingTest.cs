using System;
using System.IO;
using System.Text.Json;
using Ally.Mapping;
using Ally.Models;
using Ally.Models.Stocks;
using Shared.Enums;
using Shared.Models;
using Shouldly;
using Xunit;

namespace Tests.ally;

public class ToStockMappingTest
{
    
    private readonly Stock _stock;
    public ToStockMappingTest()
    {
        var jsonOptionString = File.ReadAllText(@"ally/files/option.json");                        
        var _optionChain = JsonSerializer.Deserialize<AllyOptionChain>(jsonOptionString);
        
        var _jsonStockString = File.ReadAllText(@"ally/files/stock.json");                        
        var _stockChain = JsonSerializer.Deserialize<AllyStockChain>(_jsonStockString);
        
        var mapToStock = new AllyMapToStock(_optionChain,_stockChain);
        _stock = mapToStock.ToStock();

    }

    [Fact]
    public void Mapped_Symbol()
    {
        _stock.Symbol.ShouldNotBeNull();
    }

    [Fact]
    public void OptionMapped_Ask()
    {
        _stock.Options[0].Ask.ShouldBePositive();
    }
    [Fact]
    public void OptionMapped_Bid()
    {
        _stock.Options[0].Bid.ShouldNotBe(0);
    }
    [Fact]
    public void OptionMapped_Delta()
    {
        _stock.Options[0].Delta.ShouldNotBe(0);
    }
    [Fact]
    public void OptionMapped_Gamma()
    {
        _stock.Options[0].Gamma.ShouldNotBe(0);
    }
    [Fact]
    public void OptionMapped_Id()
    {
        _stock.Options[0].Id.ShouldNotBeNull();
    }
    [Fact]
    public void OptionMapped_Mid()
    {
        _stock.Options[0].Mid.ShouldNotBe(0);
    }
    [Fact]
    public void OptionMapped_Theta()
    {
        _stock.Options[0].Theta.ShouldNotBe(0);
    }
    [Fact]
    public void OptionMapped_Type()
    {
        _stock.Options[0].Type.ShouldBeOneOf(OptionType.Call,OptionType.Put);;
    }
    [Fact]
    public void OptionMapped_Vega()
    {
        _stock.Options[0].Vega.ShouldNotBe(0);
    }
    [Fact]
    public void OptionMapped_Volume()
    {
        _stock.Options[0].Volume.ShouldBeGreaterThan(0);
    }
    [Fact]
    public void OptionMapped_ExpirationDate()
    {
        _stock.Options[0].ExpirationDate.ShouldBeGreaterThan(DateTime.MinValue);
    }
    [Fact]
    public void OptionMapped_ImpliedVolatility()
    {
        _stock.Options[0].ImpliedVolatility.ShouldBeGreaterThan(0);
    }
    [Fact]
    public void OptionMapped_OpenInterest()
    {
        _stock.Options[0].OpenInterest.ShouldBeGreaterThan(0);
    }
    [Fact]
    public void OptionMapped_StrikePrice()
    {
        _stock.Options[0].StrikePrice.ShouldNotBe(0);
    }
    [Fact]
    public void OptionMapped_DaysToExpiration()
    {
        _stock.Options[0].DaysToExpiration.ShouldBeGreaterThan(0);
    }
    [Fact]
    public void OptionMapped_InTheMoney()
    {
        _stock.Options[0].InTheMoney.ShouldBeTrue();
    }
    
    [Fact]
    public void Mapped_Price()
    {
        _stock.Price.ShouldNotBeNull();
    }
}