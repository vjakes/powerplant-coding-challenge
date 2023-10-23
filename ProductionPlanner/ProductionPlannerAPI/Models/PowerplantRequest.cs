using System.Text.Json.Serialization;

namespace ProductionPlannerAPI.Models
{
    /// <summary>
    /// Provides a single powerplant description received in a request.
    /// <remarks>Explicit JsonPropertyName mappings included on purpose-some names don't match up.</remarks>
    /// </summary>
    public class PowerplantRequest
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("efficiency")]
        public float Efficiency { get; set; }

        [JsonPropertyName("pmin")]
        public int PowerMin { get; set; }

        [JsonPropertyName("pmax")]
        public int PowerMax { get; set; }
    }
}
