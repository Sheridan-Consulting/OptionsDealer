using System.Text.Json.Serialization;

namespace Ally.Models.Stocks;

public class Quotes
{
    [JsonPropertyName("quotetype")]
    public string Quotetype { get; set; }

    [JsonPropertyName("quote")]
    public AllyStock Stock { get; set; }
}