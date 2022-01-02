namespace Shared.Models;

public class OptionToBuyConfProperty
{
    public string Value { get; set; }
    public Operator Operator { get; set; }
}

public enum Operator
{
    GreaterThan,
    LessThan,
    EqualTo
}