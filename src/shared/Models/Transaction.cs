namespace Shared.Models
{
    public class OptionTransaction
    {
        public Option Option { get; set; }
        public double StrikePrice { get; set; }
        public int NumberOfContracts { get; set; }
    }
}