using ProductionPlannerAPI.Services;

namespace ProductionPlannerAPI.Models
{
    /// <summary>
    /// Used internally when calculating the loads..
    /// </summary>
    public class CapacityItemPlaning
    {
        public PowerplantCapacity Capacity { get; set; }
        public ProductionPlanItem Plan { get; set; }

    }
}
