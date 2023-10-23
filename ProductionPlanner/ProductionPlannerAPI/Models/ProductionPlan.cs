using System.Text.Json.Serialization;

namespace ProductionPlannerAPI.Models
{
    /// <summary>
    /// Represents a single entry in the production plan.
    /// </summary>
    public class ProductionPlanItem
    {
        [JsonPropertyName("name")]
        public string PlantName { get; set; }

        [JsonPropertyName("p")]
        public float Power { get; set; }
    }
}
