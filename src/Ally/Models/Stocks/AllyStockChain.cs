using System.Text.Json.Serialization;

namespace Ally.Models.Stocks;

public class AllyStockChain
    {
        [JsonPropertyName("response")]
        public Response Response { get; set; }
    }

