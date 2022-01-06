using System.IO;
using System.Text.Json;
using Ally.Mapping;
using Ally.Models;
using Ally.Models.Stocks;
using Shared.Extensions;
using Shared.Models;
using Shared.Models.Rules;
using Shouldly;
using Xunit;

namespace Tests.ally;

public class FullAllyTest
{
    private OptionRuleParameters _optionRuleParameters;
    private Stock _stock;
    public FullAllyTest()
    {
        var jsonOptionString = File.ReadAllText(@"ally/files/intelsinglerecord.json");                        
        var _optionChain = JsonSerializer.Deserialize<AllyOptionChain>(jsonOptionString);
        
        var _jsonStockString = File.ReadAllText(@"ally/files/intel.json");                        
        var _stockChain = JsonSerializer.Deserialize<AllyStockChain>(_jsonStockString);
        
        var mapToStock = new AllyMapToStock(_optionChain,_stockChain);
        _stock = mapToStock.ToStock();
        
        _optionRuleParameters = new OptionRuleParameters()
        {
            Calls = false,
            Puts = true,
            AssignmentPercentage = .25,
            MinimumPremium = .2,
            PremiumPercentage = .005,
            DaysToExpiration = 14,
            MinOpenInterest = 100
        };
    }
    [Fact]
    public void RunFullTest_RunAllRules_ShouldReturOne()
    {
        _stock.RuleRunAll(_optionRuleParameters).Options.Count.ShouldBe(1); 
    }
    [Fact]
    public void RunFullTest_RuleDaysToExpiration_ShouldReturnOne()
    {
        _stock.RuleDaysToExpiration(_optionRuleParameters.DaysToExpiration).Options.Count.ShouldBe(1); 
    }
    [Fact]
    public void RunFullTest_RuleMinPremium_ShouldReturnOne()
    {
        _stock.RuleMinPremium(_optionRuleParameters.MinimumPremium).Options.Count.ShouldBe(1); 
    }
    [Fact]
    public void RunFullTest_RuleOpenInterest_ShouldReturnOne()
    {
        _stock.RuleOpenInterest(_optionRuleParameters.MinOpenInterest).Options.Count.ShouldBe(1); 
    }
    [Fact]
    public void RunFullTest_RuleOptionType_ShouldReturnOne()
    {
        _stock.RuleOptionType(_optionRuleParameters.Calls,_optionRuleParameters.Puts).Options.Count.ShouldBe(1); 
    }
    [Fact]
    public void RunFullTest_RulePremiumPercentage_ShouldReturnOne()
    {
        _stock.RulePremiumPercentage(_optionRuleParameters.PremiumPercentage).Options.Count.ShouldBe(1); 
    }
    [Fact]
    public void RunFullTest_RuleChanceOfAssignment_ShouldReturnOne()
    {
        var delta = _stock.Options[0].Delta;
        _stock.RuleChanceOfAssignment(_optionRuleParameters.AssignmentPercentage).Options.Count.ShouldBe(1,$"{_optionRuleParameters.AssignmentPercentage} vs {delta}"); 
    }
    [Fact]
    public void RunFullTest_RuleInTheMoney_ShouldReturnOne()
    {
        _stock.RuleInTheMoney().Options.Count.ShouldBe(1); 
    }
}