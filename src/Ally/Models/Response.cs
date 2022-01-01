using System;
using System.Text.Json.Serialization;

namespace Ally.Models
{
    public class Response
    {
        [JsonPropertyName("@id")]
        public string Id { get; set; }

        [JsonPropertyName("elapsedtime")]
        public string Elapsedtime { get; set; }

        [JsonPropertyName("quotes")]
        public Quotes Quotes { get; set; }

        [JsonPropertyName("error")]
        public string Error { get; set; }
    }
}

