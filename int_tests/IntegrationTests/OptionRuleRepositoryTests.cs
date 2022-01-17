using AutoFixture.Xunit2;
using Data;
using Data.Repository;
using Shared.Models.Data;
using Shared.Models.Rules;
using Shouldly;
using Xunit;

namespace IntegrationTests;

public class OptionRuleRepositoryTests : IClassFixture<DbFixture>
{
    
    private readonly DbFixture _fixture;

    public OptionRuleRepositoryTests(DbFixture fixture)
    {
        _fixture = fixture;
    }
    
    [Fact]
    public async Task Create_ShouldInsertNewUser()
    {
        var sut = new OptionRuleRepository(_fixture.Database);

        var symbols = new OptionRule()
        {
            UserId = "1",
            Symbols = new List<string>() {"AAPL", "MSFT"},
            OptionRuleParameters = new OptionRuleParameters()
        };

        var optionRule = await sut.CreateOptionRule(symbols);
        optionRule.ShouldNotBeNull();
        
        var loadedSymbol = await sut.GetOptionRuleById(optionRule.OptionRuleId);
        loadedSymbol.ShouldNotBeNull();
        loadedSymbol.Symbols.Count.ShouldBe(2);
        loadedSymbol.UserId.ShouldBe("1");
        loadedSymbol.UserId.ShouldBe(symbols.UserId);
    }

    [Fact]
    public async Task Create_ShouldBeAbleToQueryByUserId()
    {
        var sut = new OptionRuleRepository(_fixture.Database);

        var symbols = new OptionRule()
        {
            UserId = "2",
            Symbols = new List<string>() {"AAPL", "MSFT"},
            OptionRuleParameters = new OptionRuleParameters()
        };
        var id = await sut.CreateOptionRule(symbols);
        id.ShouldNotBeNull();
        
        var loadedSymbols = await sut.GetOptionRulesByUserId(symbols.UserId);
        loadedSymbols.Count.ShouldBeGreaterThan(0);
        loadedSymbols[0].UserId.ShouldBe("2");
    }

    [Theory,AutoData]
    public async Task Create_OptionRuleIdShouldNotBeNull(string userid)
    {
        var sut = new OptionRuleRepository(_fixture.Database);
        
        var optionRuleData = new OptionRule()
        {
            UserId = userid,
            Symbols = new List<string>() {"AAPL", "MSFT"},
            OptionRuleParameters = new OptionRuleParameters()
        };

        var optionRule = await sut.CreateOptionRule(optionRuleData);
        optionRule.OptionRuleId.ShouldNotBeNull();
    }

    [Fact]
    public async Task Update_ShouldUpdateSymbols()
    {
        var sut = new OptionRuleRepository(_fixture.Database);
        
        var optionRule = new OptionRule()
        {
            UserId = "3",
            Symbols = new List<string>() {"AAPL", "MSFT"},
            OptionRuleParameters = new OptionRuleParameters()
        };

        var optionRuleCreate = await sut.CreateOptionRule(optionRule);
        optionRuleCreate.ShouldNotBeNull();
        
        optionRule.Symbols.Add("F");

        var updateOptionRule = await sut.UpdateOptionRule(optionRuleCreate.OptionRuleId, optionRule);
        updateOptionRule.Symbols.Count.ShouldBe(3);
        updateOptionRule.Symbols.ShouldContain("F");
        updateOptionRule.UserId.ShouldBe("3");
    }
    [Fact]
    public async Task Update_ShouldUpdateRuleParameters()
    {
        var sut = new OptionRuleRepository(_fixture.Database);
        
        var optionRule = new OptionRule()
        {
            UserId = "4",
            Symbols = new List<string>() {"AAPL", "MSFT"},
            OptionRuleParameters = new OptionRuleParameters()
        };

        var optionRuleResponse = await sut.CreateOptionRule(optionRule);
        optionRuleResponse.ShouldNotBeNull();

        optionRule.OptionRuleParameters.MinOpenInterest = 100;

        var updateOptionRule = await sut.UpdateOptionRule(optionRuleResponse.OptionRuleId, optionRule);
        updateOptionRule.OptionRuleParameters.MinOpenInterest.ShouldBe(100);
        updateOptionRule.Symbols.Count.ShouldBePositive();
        updateOptionRule.UserId.ShouldBe("4");
        
    }

    [Theory,AutoData]
    public async Task Delete_ShouldDeleteRecord(string userId)
    {
        var sut = new OptionRuleRepository(_fixture.Database);
        
        var optionRule = new OptionRule()
        {
            UserId = userId,
            Symbols = new List<string>() {"AAPL", "MSFT"},
            OptionRuleParameters = new OptionRuleParameters()
        };

        var optionRuleResponse = await sut.CreateOptionRule(optionRule);
        optionRuleResponse.ShouldNotBeNull();

        await sut.DeleteOptionRule(optionRuleResponse.OptionRuleId);

        var record = await sut.GetOptionRuleById(optionRuleResponse.OptionRuleId);
        record.ShouldBeNull();
        


    }
    
   
}