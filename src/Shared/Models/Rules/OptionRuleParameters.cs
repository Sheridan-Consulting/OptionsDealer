namespace Shared.Models.Rules;

public class OptionRuleParameters
{
    public double AssignmentPercentage { get; set; }
    public int MinOpenInterest { get; set; }
    public double PremiumPercentage { get; set; }
    public int DaysToExpiration { get; set; }
}