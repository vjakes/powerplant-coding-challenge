using System.Collections;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ProductionPlannerAPI.Models
{
    /// <summary>
    /// Represents a request for power production
    /// </summary>
    public class ProductionRequest
    {
        [JsonPropertyName("load")]
        public float Load { get; set; }
        [JsonPropertyName("fuels")]
        public FuelRequest Fuels { get; set; }
        [JsonPropertyName("powerplants")]
        public ICollection<PowerplantRequest> Powerplants { get; set; }

    }
}
