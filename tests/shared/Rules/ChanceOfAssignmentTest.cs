using Shared.Models;
using Shared.Rules;
using Shouldly;
using Xunit;

namespace Tests.Shared.Rules;

public class ChanceOfAssignmentTest : RulesTestBase
{
    public ChanceOfAssignmentTest() : base()
    {
    }

    [Fact]
    public void Stock_DeltaIsNegativeInRange_ShouldBeValid()
    {
        var optionChanceOfAssignment = new Option() {Delta = -.18};
        base.Stock.Options.Add(optionChanceOfAssignment);

        var chanceOfAssignmentRule = new ChanceOfAssignment(.2);

        var ruleTest = chanceOfAssignmentRule.Evaluate(base.Stock);
        
        ruleTest.Count.ShouldBe(1);
    }
    [Fact]
    public void Stock_DeltaIsNegativeOutOfRange_ShouldBeValid()
    {
        var optionChanceOfAssignment = new Option() {Delta = -.48};
        base.Stock.Options.Add(optionChanceOfAssignment);

        var chanceOfAssignmentRule = new ChanceOfAssignment(.2);

        var ruleTest = chanceOfAssignmentRule.Evaluate(base.Stock);
        
        ruleTest.Count.ShouldBe(0);
    }
    [Fact]
    public void Stock_DeltaIsPositveInRange_ShouldBeValid()
    {
        var optionChanceOfAssignment = new Option() {Delta = .18};
        base.Stock.Options.Add(optionChanceOfAssignment);

        var chanceOfAssignmentRule = new ChanceOfAssignment(.2);

        var ruleTest = chanceOfAssignmentRule.Evaluate(base.Stock);
        
        ruleTest.Count.ShouldBe(1);
    }
    [Fact]
    public void Stock_DeltaIsPositiveOutOfRange_ShouldBeValid()
    {
        var optionChanceOfAssignment = new Option() {Delta = .48};
        base.Stock.Options.Add(optionChanceOfAssignment);

        var chanceOfAssignmentRule = new ChanceOfAssignment(.2);

        var ruleTest = chanceOfAssignmentRule.Evaluate(base.Stock);
        
        ruleTest.Count.ShouldBe(0);
    }
    [Fact]
    public void Stock_TwoDeltaOneInRanage_ShouldReturnOne()
    {
        var optionChanceOfAssignment = new Option() {Delta = .48};
        var optionChanceOfAssignment1 = new Option() {Delta = .18};
        base.Stock.Options.Add(optionChanceOfAssignment);
        base.Stock.Options.Add(optionChanceOfAssignment1);

        var chanceOfAssignmentRule = new ChanceOfAssignment(.2);

        var ruleTest = chanceOfAssignmentRule.Evaluate(base.Stock);
        
        ruleTest.Count.ShouldBe(1);
    }
}