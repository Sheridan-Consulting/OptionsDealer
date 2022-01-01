using System;
using System.Text.Json.Serialization;

namespace Ally.Models
{
    public class AllyOptionChain
    {
        [JsonPropertyName("response")]
        public Response Response { get; set; }
    }
}

