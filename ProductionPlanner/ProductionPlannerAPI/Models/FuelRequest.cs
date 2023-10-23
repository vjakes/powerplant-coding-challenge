using System.Text.Json.Serialization;

namespace ProductionPlannerAPI.Models
{
    public class FuelRequest
    {
        [JsonPropertyName("gas(euro/MWh)")]
        public float GasCostMWh { get; set; }

        [JsonPropertyName("kerosine(euro/MWh)")]
        public float KerosineCostMWh { get; set; }

        [JsonPropertyName("co2(euro/ton)")]
        public float CO2CostPerTonne { get; set; }

        [JsonPropertyName("wind(%)")]
        public int Efficiency { get; set; }

    }
}
