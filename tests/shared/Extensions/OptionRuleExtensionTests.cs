using System.Collections.Generic;
using Shared.Extensions;
using Shared.Models;
using Shouldly;
using Xunit;

namespace Tests.Shared.Extensions;

public class OptionRuleExtensionTests
{
    private readonly Stock _stock;
    public OptionRuleExtensionTests()
    {
        _stock = new Stock()
        {
            Price = 50.0,
            Symbol = "AAPL",
            Options = new List<Option>()
        };
    }
    [Fact]
    public void ChanceOfAssignment_DeltaIsNegativeInRange_ShouldBeValid()
    {
        var optionChanceOfAssignment = new Option() {Delta = -.18};
        _stock.Options.Add(optionChanceOfAssignment);

        var ruleTest = _stock.RuleChanceOfAssignment(.2);
        
        ruleTest.Options.Count.ShouldBe(1);
    }
    
    [Fact]
    public void ChanceOfAssignment_DeltaIsNegativeOutOfRange_ShouldBeValid()
    {
        var optionChanceOfAssignment = new Option() {Delta = -.48};
        _stock.Options.Add(optionChanceOfAssignment);

        var ruleTest = _stock.RuleChanceOfAssignment(.2);
        
        ruleTest.Options.Count.ShouldBe(0);
    }
    [Fact]
    public void ChanceOfAssignment_DeltaIsPositiveInRange_ShouldBeValid()
    {
        var optionChanceOfAssignment = new Option() {Delta = .18};
        _stock.Options.Add(optionChanceOfAssignment);

        var ruleTest = _stock.RuleChanceOfAssignment(.2);
        
        ruleTest.Options.Count.ShouldBe(1);
    }
    [Fact]
    public void ChanceOfAssignment_DeltaIsPositiveOutOfRange_ShouldBeValid()
    {
        var optionChanceOfAssignment = new Option() {Delta = .48};
        _stock.Options.Add(optionChanceOfAssignment);

        var ruleTest = _stock.RuleChanceOfAssignment(.2);
        
        ruleTest.Options.Count.ShouldBe(0);
    }
    [Fact]
    public void ChanceOfAssignment_TwoDeltaOneInRange_ShouldReturnOne()
    {
        var optionChanceOfAssignment = new Option() {Delta = .48};
        var optionChanceOfAssignment1 = new Option() {Delta = .18};
        _stock.Options.Add(optionChanceOfAssignment);
        _stock.Options.Add(optionChanceOfAssignment1);

        _stock.Options.Add(optionChanceOfAssignment);

        var ruleTest = _stock.RuleChanceOfAssignment(.2);
        
        ruleTest.Options.Count.ShouldBe(1);
    }
    [Fact]
    public void InTheMoney_TwoOptions_OneInMoney()
    {
        var optionOutOfMoney = new Option() {InTheMoney = false};
        var optionInTheMoney = new Option() {InTheMoney = true};
        _stock.Options.Add(optionInTheMoney);
        _stock.Options.Add(optionOutOfMoney);

        var ruleTest = _stock.RuleInTheMoney();
        
        ruleTest.Options.Count.ShouldBe(1);
    }
    [Fact]
    public void InTheMoney_OneOptions_OneInMoney()
    {
        var optionInTheMoney = new Option() {InTheMoney = true};
        _stock.Options.Add(optionInTheMoney);

        var ruleTest = _stock.RuleInTheMoney();
        
        ruleTest.Options.Count.ShouldBe(1);
    }
}