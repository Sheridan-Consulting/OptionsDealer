using System;
using System.Text.Json.Serialization;

namespace Ally.Models
{
    public class Quotes
    {
        [JsonPropertyName("quote")]
        public List<Strike> Strikes { get; set; }
    }
}

