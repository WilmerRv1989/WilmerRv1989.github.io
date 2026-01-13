using System.Text.Json.Serialization;

namespace PortafolioBlog.Models
{
    public class ContadorResponse
    {
        [JsonPropertyName("count")]
        public long Value { get; set; }
    }
}
