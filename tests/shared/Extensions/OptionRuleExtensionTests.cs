using System.Collections.Generic;
using System.Runtime.InteropServices;
using Shared.Extensions;
using Shared.Models;
using Shared.Models.Rules;
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

    [Fact]
    public void OpenInterest_OneOption_OpenInterestAboveLimit()
    {
        var option1 = new Option() {OpenInterest = 100};
        _stock.Options.Add(option1);

        var ruleTest = _stock.RuleOpenInterest(99);
        
        ruleTest.Options.Count.ShouldBe(1);
    }
    [Fact]
    public void OpenInterest_OneOption_OpenInterestBelowLimit()
    {
        var option1 = new Option() {OpenInterest = 50};
        _stock.Options.Add(option1);

        var ruleTest = _stock.RuleOpenInterest(99);
        
        ruleTest.Options.Count.ShouldBe(0);
    }
    [Fact]
    public void OpenInterest_TwoOptions_OneOpenInterestBelowLimit()
    {
        var option1 = new Option() {OpenInterest = 50};
        var option2 = new Option() {OpenInterest = 100};
        _stock.Options.Add(option1);
        _stock.Options.Add(option2);

        var ruleTest = _stock.RuleOpenInterest(99);
        
        ruleTest.Options.Count.ShouldBe(1);
    }

    [Theory]
    [InlineData(5,50,.1)]
    [InlineData(18,177.5,.1)]
    [InlineData(.33,29,.01)]
    public void PremiumPercentage_OneOptionSatisfyRule_CountShouldBeOne(double mid,double strike,double percent)
    {
        var option1 = new Option() {Mid = mid, StrikePrice = strike};
        _stock.Options.Add(option1);

        var ruleTest = _stock.RulePremiumPercentage(percent);
        
        ruleTest.Options.Count.ShouldBe(1);
    }
    [Theory]
    [InlineData(3,50,.1)]
    [InlineData(.03,24,.01)]
    public void PremiumPercentage_OneOptionNotSatisfyRule_CountShouldBeNone(double mid,double strike,double percent)
    {
        var option1 = new Option() {Mid = mid, StrikePrice = strike};
        _stock.Options.Add(option1);

        var ruleTest = _stock.RulePremiumPercentage(percent);
        
        ruleTest.Options.Count.ShouldBe(0);
    }

    [Theory]
    [InlineData(.33,29,true,-.1486,2946,100,.01,.2)]
    public void OptionRuleRunAll_SatisfiesConditions_ShouldReturnOne(double mid, double strike, bool inTheMoney, double delta,int openInterest,
        int openInterestLimit, double premiumPercentage, double chanceOfAssignment)
    {
        var option = new Option()
            {Mid = mid, StrikePrice = strike, InTheMoney = inTheMoney, Delta = delta, OpenInterest = openInterest};
        _stock.Options.Add(option);

        var optionParams = new OptionRuleParameters()
        {
            AssignmentPercentage = chanceOfAssignment, PremiumPercentage = premiumPercentage,
            MinOpenInterest = openInterestLimit
        };

        var validOptions = _stock.RuleRunAll(optionParams);
        
        validOptions.Options.Count.ShouldBe(1);
    }
    [Theory]
    [InlineData(.05,23,true,-.0028,528,100,.01,.2)]
    public void OptionRuleRunAll_DoesNotSatisfiesConditions_ShouldReturnNone(double mid, double strike, bool inTheMoney, double delta,int openInterest,
        int openInterestLimit, double premiumPercentage, double chanceOfAssignment)
    {
        var option = new Option()
            {Mid = mid, StrikePrice = strike, InTheMoney = inTheMoney, Delta = delta, OpenInterest = openInterest};
        _stock.Options.Add(option);
        
        var optionParams = new OptionRuleParameters()
        {
            AssignmentPercentage = chanceOfAssignment, PremiumPercentage = premiumPercentage,
            MinOpenInterest = openInterestLimit
        };

        var validOptions = _stock.RuleRunAll(optionParams);
        
        validOptions.Options.Count.ShouldBe(0);
    }
}