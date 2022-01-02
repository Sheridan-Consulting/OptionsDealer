using Shared.Models;
using Shared.Rules;
using Shouldly;
using Xunit;

namespace Tests.Shared.Rules;

public class InTheMoneyTests : RulesTestBase
{
    public InTheMoneyTests() : base(){}

    [Fact]
    public void Stock_TwoOptions_OneInMoney()
    {
        var optionOutOfMoney = new Option() {InTheMoney = false};
        var optionInTheMoney = new Option() {InTheMoney = true};
        base.Stock.Options.Add(optionInTheMoney);
        base.Stock.Options.Add(optionOutOfMoney);

        var inTheMoneyRule = new InTheMoneyRule();

        var ruleTest = inTheMoneyRule.Evaluate(base.Stock);
        
        ruleTest.Count.ShouldBe(1);
    }
    [Fact]
    public void Stock_OneOptions_OneInMoney()
    {
        var optionInTheMoney = new Option() {InTheMoney = true};
        base.Stock.Options.Add(optionInTheMoney);

        var inTheMoneyRule = new InTheMoneyRule();

        var ruleTest = inTheMoneyRule.Evaluate(base.Stock);
        
        ruleTest.Count.ShouldBe(1);
    }
}